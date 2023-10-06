using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitScene = "Init";

        private readonly AllServices _services;
        private readonly IGameStateMachine _stateMachine;

        public BootstrapState(IGameStateMachine stateMachine, AllServices services)
        {
            _stateMachine = stateMachine;
            _services = services;

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
            _services.RegisterSingle<IInputService>(new InputService());

            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>(), _services.Single<IInputService>()));
        }

        private void EnterLoadProgress() =>
            _stateMachine.Enter<LoadProgressState>();
    }
}