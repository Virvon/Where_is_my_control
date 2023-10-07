using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class MenuState : IState
    {
        private IGameFactory _gameFactory;

        public MenuState(IGameStateMachine stateMachine, IGameFactory factory)
        {
            _gameFactory = factory;
        }

        public void Enter()
        {
            _gameFactory.CreateMainMenu();
        }

        public void Exit()
        {
            
        }
    }
}