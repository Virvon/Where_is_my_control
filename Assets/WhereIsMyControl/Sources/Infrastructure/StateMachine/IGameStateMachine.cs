using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public interface IGameStateMachine : IService
    {
        void Enter<TState>() where TState : class, IState;
        void Enter<TState, TPayload> (TPayload payload) where TState : class, IPayloadState<TPayload>;
    }
}