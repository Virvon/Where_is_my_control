using System;
using System.Collections;
using UnityEngine;
using WhereIsMyControl.Infrastructure;
using WhereIsMyControl.Input;

namespace WhereIsMyControl.Services
{
    public class InputService : IInputService
    {
        private readonly PlayerInput _input;
        private readonly ICoroutineRunner _coroutineRunner;

        public event Action Jumped;

        public InputService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;

            _input = new();
            _input.Enable();

            coroutineRunner.StartCoroutine(Update());
        }

        private IEnumerator Update()
        {
            while (true)
            {
                if(_input.Player.Jump.phase == UnityEngine.InputSystem.InputActionPhase.Started)
                    Jumped?.Invoke();

                yield return null;
            }
        }
    }
}
