using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Callback = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Gameplay.Characters.SubSystems
{
    internal class InputControl : IControl, IDisposable
    {
        public Vector2 Direction => IsActive ? _input.ReadValue<Vector2>() : Vector2.zero;
        public bool IsActive { private set; get; }

        public event Action Start, Cancel;

        private InputAction _input;
        private Action<Callback> _start, _cancel;

        internal InputControl(InputAction input)
        {
            _input = input;
            Initialize();
        }
        
        public void Dispose()
        {
            _input.started -= _start;
            _input.canceled -= _cancel;
            _input.started -= Pressed;
            _input.canceled -= Pressed;
        }
        public void Check()
        {
            throw new NotImplementedException();
        }

        private void Initialize()
        {
            _start = (Callback _) => Start?.Invoke();
            _cancel = (Callback _) => Cancel?.Invoke();

            _input.started += _start;
            _input.canceled += _cancel;
            _input.started += Pressed;
            _input.canceled += Pressed;
        }
        private void Pressed(Callback obj)
        {
            IsActive = !IsActive;
        }
    }
}