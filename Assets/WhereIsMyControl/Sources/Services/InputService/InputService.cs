using System;
using WhereIsMyControl.Input;

namespace WhereIsMyControl.Services
{
    public class InputService : IInputService
    {
        private readonly PlayerInput _input;

        public event Action Jumped;

        public InputService()
        {
            _input = new();
            _input.Enable();

            _input.Player.Jump.performed += _ => OnJump();
        }

        private void OnJump() =>
            Jumped?.Invoke();
    }
}
