using UnityEngine;
using System;

namespace Gameplay
{
    public class LightsBackground : MonoCached
    {
        [SerializeField] private Light _light;
        [SerializeField] private TimeOfDay _time;

        [SerializeField] private float _intensivityDay = 1.3f;
        [SerializeField] private float _intensivityNight = 0;

        protected override void OnEnable()
        {
            if (_light == null ||
                _time == null)
                throw new Exception();

            base.OnEnable();

            _time.OnDay += OnLight;
            _time.OnNight += OnDark;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _time.OnDay -= OnLight;
            _time.OnNight -= OnDark;
        }

        private void OnDark()
        {
            _light.intensity = _intensivityNight;
        }

        private void OnLight()
        {
            _light.intensity = _intensivityDay;
        }
    }
}