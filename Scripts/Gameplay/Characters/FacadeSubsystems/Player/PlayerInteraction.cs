using System.Collections;
using UnityEngine.InputSystem;
using System;

namespace Gameplay.Characters.SubSystems
{
    public class PlayerInteraction : IInteraction
    {
        public Action ActionDelayed { private get; set; }
        Action<IInteractable> IInteraction.ActionDelayed { set => throw new NotImplementedException(); }

        internal PlayerInteraction(InputAction interactionInput)
        {
            interactionInput.performed += Interaction;
        }

        private void Interaction(InputAction.CallbackContext obj)
        {
            ActionDelayed?.Invoke();
            ActionDelayed = null;
        }
    }
}