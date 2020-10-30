using System;
using System.Linq;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    internal class MoveTranslate : IMoveable
    {
        private readonly IManagement _management;
        private readonly float _speed = 1;
        private readonly IUpdate _managementUpdate;
        private readonly Transform _transform;

        /// <summary>
        /// Физическое движение
        /// </summary>
        /// <param name="management">Способ управления движвением</param>
        /// <param name="rigidbody"></param>
        /// <param name="speed"></param>
        internal MoveTranslate(IManagement management, Transform transform, float speed)
        {
            if (management == null || transform == null)
                throw new ArgumentNullException();

            _transform = transform;
            _management = management;
            _speed = speed;
            _managementUpdate = _management as IUpdate;
        }

        public void Move()
        {
            if (_management.IsActive == true)
            {
                _transform.Translate(_management.Direction * _speed / 100);
                _managementUpdate?.Update();
            }
        }
    }
}