using System;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    internal class AIManagement : IManagement, IUpdate
    {
        public bool IsActive => true;
        public event Action Start;
        public event Action Cancel;

        public Vector2 Direction { get; private set; }

        private ITrafficRoute _trafficRoute;
        private IDetectable _detectable;
        private bool _isBindToTarget;


        internal AIManagement(ITrafficRoute trafficRoute, IDetectable detectable = null)
        {
            _trafficRoute = trafficRoute;
            _detectable = detectable;
            Initialize();
        }

        public void Update()
        {
            if (_isBindToTarget == false)
                Direction = _trafficRoute.Direction;
        }

        private void Initialize()
        {
            Start?.Invoke();
            Direction = _trafficRoute.Direction;
            if (_detectable != null)
            {
                _detectable.Detect = (Character character) =>
                {
                    Direction = character.transform.position;
                    _isBindToTarget = true;
                };
            }
        }
    }
}