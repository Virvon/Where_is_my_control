using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class Game
    {
        private GameStateMachine _stateMachine;

        public Game()
        {
            _stateMachine = new GameStateMachine(AllServices.Instance);

            _stateMachine.Enter<BootstrapState>();
        }
    }
}
