using System;
using System.Linq;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    internal class MoveTranslate : IMoveable
    {
        private readonly IControl _control;
        private readonly float _speed = 1;
        private readonly Transform _transform;

        /// <summary>
        /// Физическое движение
        /// </summary>
        /// <param name="control">Способ управления движвением</param>
        /// <param name="rigidbody"></param>
        /// <param name="speed"></param>
        internal MoveTranslate(IControl control, Transform transform, float speed)
        {
            if (control == null || transform == null)
                throw new ArgumentNullException();

            _transform = transform;
            _control = control;
            _speed = speed;
        }

        public void Move()
        {
            if (_control.IsActive == true)
            {
                _transform.Translate(_control.Direction * _speed / 100);
            }
        }
    }
}