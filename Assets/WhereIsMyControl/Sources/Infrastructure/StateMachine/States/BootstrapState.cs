using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitScene = "Init";

        private readonly AllServices _services;
        private readonly IGameStateMachine _stateMachine;
        private readonly ICoroutineRunner _coroutineRunner;

        public BootstrapState(IGameStateMachine stateMachine, AllServices services, ICoroutineRunner coroutineRunner)
        {
            _stateMachine = stateMachine;
            _services = services;
            _coroutineRunner = coroutineRunner;

            RegisterServices();
        }

        public void Enter()
        {
            _services.Single<ISceneLoader>().Load(InitScene, callback: EnterLoadProgress);
        }

        public void Exit()
        {

        }

        private void RegisterServices()
        {
            _services.RegisterSingle<ISceneLoader>(new SceneLoader());
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            _services.RegisterSingle<IInputService>(new InputService(_coroutineRunner));
            _services.RegisterSingle(_stateMachine);

            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>(), _services.Single<IInputService>(), _services.Single<IGameStateMachine>(), _services.Single<ISceneLoader>()));
        }

        private void EnterLoadProgress() =>
            _stateMachine.Enter<LoadProgressState>();
    }
}