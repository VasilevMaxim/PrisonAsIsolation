using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Callback = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace Gameplay.Characters.SubSystems
{
    internal class InputManagement : IManagement
    {
        public Vector2 Direction => IsActive ? _input.ReadValue<Vector2>() : Vector2.zero;
        public bool IsActive { private set; get; }

        public event Action Start;
        public event Action Cancel;

        private InputAction _input;
        internal InputManagement(InputAction input)
        {
            _input = input;
            Init();
        }

        private void Init()
        {
            _input.started += (Callback _) => Start?.Invoke();
            _input.canceled += (Callback _) => Cancel?.Invoke();
            _input.started += Pressed;
            _input.canceled += Pressed;
        }

        private void Pressed(Callback obj)
        {
            IsActive = !IsActive;
        }

        public void Check()
        {

        }
    }
}