using System;
using System.Collections.Generic;

namespace WhereIsMyControl.Infrastructure
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;

        private IState _currentState;

        public GameStateMachine()
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(),
                [typeof(LoadProgressState)] = new LoadProgressState()
            };
        }

        public void Enter<TState>() where TState : IState
        {
            _currentState?.Exit();

            IState state = _states[typeof(TState)];

            _currentState = state;
            _currentState.Enter();
        }
    }
}
