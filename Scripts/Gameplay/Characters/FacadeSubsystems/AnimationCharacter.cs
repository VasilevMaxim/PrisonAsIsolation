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
        private IManagement _management;

        internal AnimationCharacter(IManagement management, Animator animator, NamesAnimationsCharacter names)
        {
            _management = management;
            _animator = animator;
            _names = names;

            Initialize();
        }

        private void Initialize()
        {
            _management.Cancel += () =>
            {
                _animator.SetFloat(_names.X, 0);
                _animator.SetFloat(_names.Y, 0);
            };
        }

        public void MoveAnimate()
        {
            var direction = _management.Direction;
            _animator.SetFloat(_names.X, direction.x);
            _animator.SetFloat(_names.Y, direction.y);
        }

        public void Update()
        {
            if (_management.IsActive == true)
                MoveAnimate();
        }
    }
}
