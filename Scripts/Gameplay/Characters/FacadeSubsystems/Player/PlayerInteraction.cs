using System.Collections;
using UnityEngine.InputSystem;
using System;

namespace Gameplay.Characters.SubSystems
{
    internal class PlayerInteraction : IInteraction
    {
        public Action<Character> ActionDelayed { private get; set; }
        private Character _character;
        private HintView _hint;

        internal PlayerInteraction(InputAction interactionInput, Character character, HintView hint = null)
        {
            interactionInput.performed += Interaction;
            _character = character;
            _hint = hint;
        }

        private void Interaction(InputAction.CallbackContext obj)
        {
            ExitAccess();
            ActionDelayed?.Invoke(_character);
            ActionDelayed = null;
        }

        public void OpenAccess()
        {
            _hint?.PressF(true);
        }

        public void ExitAccess()
        {
            _hint?.PressF(false);
        }
    }
}