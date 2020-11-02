using Gameplay.Characters;
using Interface;
using System.Linq;
using UnityEngine;

namespace Gameplay.Items
{
    [RequireComponent(typeof(BoxCollider2D))]
    internal class Door : Item
    {
        [SerializeField] private SpriteRenderer _open, _close;
        [SerializeField] private int _idKey;
        [SerializeField] private TimeOfDay _time;

        private bool _isOpen;

        protected override void OnEnable()
        {
            base.OnEnable();
            _time.OnNight += Close;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _time.OnNight -= Close;
        }

        internal override void Interaction(IInteractable interactable)
        {
            var character = interactable as Character;
            if (character == null)
                return;

            var isHaveKey = character.Storage.Resources.Contains(new ResourceData(_idKey));
            if (isHaveKey == false)
            {
                _hint?.NotPossible();
                return;
            }

            _isOpen = !_isOpen;
            if (_isOpen == true)
                Open();
            else
                Close();

        }

        public void Open()
        {
            _open.gameObject.SetActive(true);
            _close.gameObject.SetActive(false);
        }
        public void Close()
        {
            _open.gameObject.SetActive(false);
            _close.gameObject.SetActive(true);
        }
    }
}
