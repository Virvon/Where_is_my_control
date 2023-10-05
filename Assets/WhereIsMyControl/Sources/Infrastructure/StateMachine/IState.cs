namespace WhereIsMyControl.Infrastructure
{
    public interface IState
    {
        void Enter();
        void Exit();
    }
}
