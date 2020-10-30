using System;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    [RequireComponent(typeof(CircleCollider2D))]
    internal class EnemyDetectable : MonoCached, IDetectable
    {
        public Action<Character> Detect { private get; set; }
        [SerializeField] private DefeatView _defeat;
      
        private void OnTriggerEnter2D(Collider2D obj)
        {
            var character = obj.GetComponent<Character>();
            if (character != null)
            {
                _defeat?.Defeat();
                Detect?.Invoke(character);
            }
        }
    }
}