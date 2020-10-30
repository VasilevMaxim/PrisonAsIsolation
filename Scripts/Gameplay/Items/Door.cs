using Gameplay.Characters;
using System.Linq;
using UnityEngine;

namespace Gameplay.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class Door : Item
    {
        [SerializeField] private SpriteRenderer _open;
        [SerializeField] private SpriteRenderer _close;
        [SerializeField] private int _idKey;
        private bool _isOpen;

        internal override void Interaction(Character character)
        {
            var isKey = character.Storage.Resources.Contains(new ResourceData(_idKey));
            if (isKey == false)
            {
                _hint?.NotPossible();
                return;
            }

            _isOpen = !_isOpen;
            if (_isOpen == true)
            {
                _open.gameObject.SetActive(true);
                _close.gameObject.SetActive(false);
            }
            else
            {
                _open.gameObject.SetActive(false);
                _close.gameObject.SetActive(true);
            }

        }

        public void Open(bool state)
        {
            _isOpen = state;
            if (_isOpen == true)
            {
                _open.gameObject.SetActive(true);
                _close.gameObject.SetActive(false);
            }
            else
            {
                _open.gameObject.SetActive(false);
                _close.gameObject.SetActive(true);
            }
        }
    }
}
