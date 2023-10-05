namespace WhereIsMyControl.Infrastructure
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        public Game()
        {
            _stateMachine = new GameStateMachine();

            _stateMachine.Enter<BootstrapState>();
        }
    }
}
