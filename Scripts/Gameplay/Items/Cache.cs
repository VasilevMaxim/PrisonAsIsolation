using Gameplay.Characters;
using UnityEngine;

namespace Gameplay.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class Cache : Item
    {
        private Storage _storage;

        protected override void OnEnable()
        {
            base.OnEnable();
            _storage = new Storage(1);
        }

        internal override void Interaction(IInteractable interactable)
        {
            var character = interactable as Character;
            if (character == null)
                return;

            if (character.Storage.IsFree() == false)
            {
                if (_storage.IsFull() == true)
                {
                     _hint.NotPossible();
                    return;
                }

                Transfer(character);
            }
            else
            {
                if (_storage.IsFree() == true)
                {
                   _hint.NotPossible();
                    return;
                }
                
                Receive(character);
            }
        }

        private void Receive(Character character)
        {
            var resource = _storage.PopFirstOccupied();
            character.Storage.PushFirstFree(resource);
            _hint.Receive();
        }

        private void Transfer(Character character)
        {
            var resource = character.Storage.PopFirstOccupied();
            _storage.PushFirstFree(resource);
            _hint.Transfer();
        }
    }
}   