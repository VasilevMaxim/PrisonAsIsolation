using Gameplay.Characters;
using System;
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

        internal override void Interaction(Character player)
        {
            if (player.Storage.IsFree() == false)
            {
                if (_storage.IsFull() == true)
                {
                    _hint.NotPossible();
                    return;
                }

                var resource = player.Storage.PopFirstOccupied();
                _storage.PushFirstFree(resource);

                _hint.Transfer();
            }
            else
            {
                if (_storage.IsFree() == true)
                {
                    _hint.NotPossible();
                    return;
                }

                var resource = _storage.PopFirstOccupied();
                player.Storage.PushFirstFree(resource);

                _hint.Receive();
            }
        }
    }
}   