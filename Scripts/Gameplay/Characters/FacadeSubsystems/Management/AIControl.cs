using System;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    internal class AIControl : IControl
    {
        public event Action Start, Cancel; 
        
        public Vector2 Direction { get; private set; }
        public bool IsActive => true;

        private ITrafficRoute _trafficRoute;
        private IDetectable _detectable;
        private bool _isBindToTarget;

        internal AIControl(ITrafficRoute trafficRoute, IDetectable detectable = null)
        {
            _trafficRoute = trafficRoute;
            _detectable = detectable;
            Initialize();
        }

        public void Check()
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