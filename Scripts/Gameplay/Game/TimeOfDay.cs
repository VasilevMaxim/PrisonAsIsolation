using UnityEngine;
using System.Collections;
using System;
using Interface;

// In the future we can enable Zenject.
// For now, we will refer directly to the class object. 

namespace Gameplay
{
    /// <summary>
    /// Monitoring the state of the day.
    /// </summary>
    internal class TimeOfDay : MonoCached
    {
        internal event Action OnDay, OnNight;

        [Range(1, 100)]
        [SerializeField] private int _timeDay;
        [SerializeField] private TimerView _timer;

        private int _time;
        private bool _isNight;

        protected override void OnEnable()
        {
            if (_timer == null)
                throw new Exception();

            base.OnEnable();

            _time = _timeDay;
            StartCoroutine(TimerCoroutine());
        }

        private IEnumerator TimerCoroutine()
        {
            while (enabled == true)
            {
                while (_time-- > 0)
                {
                    yield return new WaitForSeconds(1f);
                    _timer.SetSecond(_time);
                }
                _time = _timeDay;

                SwitchDay();
            }
        }

        private void SwitchDay()
        {
            _isNight = !_isNight;

            if (_isNight == true)
                OnNight?.Invoke();
            else
                OnDay?.Invoke();
        }
    }
}