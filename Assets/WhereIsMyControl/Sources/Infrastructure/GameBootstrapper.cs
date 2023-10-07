using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WhereIsMyControl.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}