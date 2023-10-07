using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class Game
    {
        public IGameStateMachine StateMachine { get; private set; }

        public Game(ICoroutineRunner coroutineRunner)
        {
            StateMachine = new GameStateMachine(AllServices.Instance, coroutineRunner);
        }
    }
}
