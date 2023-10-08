using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class CutSceneState : IState
    {
        private const string CutScene = "CutScene";

        private readonly IGameStateMachine _stateMachine;
        private readonly ISceneLoader _sceneLoader;

        public CutSceneState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(CutScene);
        }

        public void Exit()
        {
            
        }
    }
}