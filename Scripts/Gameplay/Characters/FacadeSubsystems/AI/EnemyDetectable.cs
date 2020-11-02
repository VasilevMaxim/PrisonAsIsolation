using System;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    [RequireComponent(typeof(CircleCollider2D))]
    internal class EnemyDetectable : MonoCached, IDetectable
    {
        public Action<Character> Detect { private get; set; }
      
        private void OnTriggerEnter2D(Collider2D obj)
        {
            var character = obj.GetComponent<Character>();
            if (character != null)
                Detect?.Invoke(character);
        }
    }
}