using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using System.Collections.Generic;

namespace Gameplay.Characters.SubSystems
{
    internal class AnimationCharacter : IAnimatableCharacter
    {
        private Animator _animator;
        private NamesAnimationsCharacter _names;
        private IControl _control;

        internal AnimationCharacter(IControl control, Animator animator, NamesAnimationsCharacter names)
        {
            _control = control;
            _animator = animator;
            _names = names;

            Initialize();
        }

        private void Initialize()
        {
            _control.Cancel += () =>
            {
                _animator.SetFloat(_names.X, 0);
                _animator.SetFloat(_names.Y, 0);
            };
        }

        public void MoveAnimate()
        {
            var direction = _control.Direction;
            _animator.SetFloat(_names.X, direction.x);
            _animator.SetFloat(_names.Y, direction.y);
        }

        public void Update()
        {
            if (_control.IsActive == true)
                MoveAnimate();
        }
    }
}
