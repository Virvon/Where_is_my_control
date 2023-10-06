namespace WhereIsMyControl.Infrastructure
{
    public class LoadProgressState : IState
    {
        private const string LevelScene = "Level1";

        private readonly IGameStateMachine _stateMachine;

        public LoadProgressState(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _stateMachine.Enter<LoadLevelState, string>(LevelScene);
        }

        public void Exit()
        {
            
        }
    }
}