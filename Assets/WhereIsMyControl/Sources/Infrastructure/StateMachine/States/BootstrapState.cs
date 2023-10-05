using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitScene = "";

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
            _services.Single<SceneLoader>().Load(InitScene, callback: EnterLoadProgress);
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<ISceneLoader>(new SceneLoader());
        }

        private void EnterLoadProgress() => 
            _stateMachine.Enter<LoadProgressState>();
    }
}