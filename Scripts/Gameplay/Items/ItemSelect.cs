using Gameplay.Characters;
using UnityEngine;

namespace Gameplay.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class ItemSelect : Item
    {
        internal override void Interaction(IInteractable interactable)
        {
            var character = interactable as Character;
            if (character == null)
                return;

            if (character.Storage.IsFull() == false)
            {
                character.Storage.PushFirstFree(this);
                Destroy(gameObject);
            }
        }
    }
}