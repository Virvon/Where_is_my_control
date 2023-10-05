using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class BootstrapState : IState
    {
        private const string InitScene = "";

        private readonly AllServices _services;

        public BootstrapState(AllServices services)
        {
            RegisterServices();
            _services = services;
        }

        public void Enter()
        {
            _services.Single<SceneLoader>().Load(InitScene, callback:)
        }

        public void Exit()
        {
            
        }

        private void RegisterServices()
        {
            _services.RegisterSingle<ISceneLoader>(new SceneLoader());
        }
    }
}