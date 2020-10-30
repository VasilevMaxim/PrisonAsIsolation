using Gameplay.Characters;
using UnityEngine;

namespace Gameplay.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class ItemSelect : Item
    {
        internal override void Interaction(Character player)
        {
            if (player.Storage.IsFull() == false)
            {
                player.Storage.PushFirstFree(this);
                Destroy(gameObject);
                _hint.Receive();
            }
            else
            {
                _hint.NotPossible();
            }
        }
    }
}