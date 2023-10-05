namespace WhereIsMyControl.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
    }
}
