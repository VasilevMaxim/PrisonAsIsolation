using Gameplay.Characters;
using UnityEngine;

namespace Gameplay.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class Wall : Item
    {
        [SerializeField] private uint _health;

        internal override void Interaction(Character player)
        {
            _health--;
            if (_health == 0)
                Destroy(gameObject);
        }
    }
}