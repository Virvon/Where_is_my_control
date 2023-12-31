﻿using System;
using System.Collections.Generic;
using WhereIsMyControl.Services;

namespace WhereIsMyControl.Infrastructure
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;

        private IExitableState _currentState;

        public GameStateMachine(AllServices services, ICoroutineRunner coroutineRunner)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, services, coroutineRunner),
                [typeof(CutSceneState)] = new CutSceneState(this, services.Single<ISceneLoader>()),
                [typeof(LoadLevelState)] = new LoadLevelState(this, services.Single<ISceneLoader>(), services.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(),
                [typeof(MenuState)] = new MenuState(this, services.Single<IGameFactory>())
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
