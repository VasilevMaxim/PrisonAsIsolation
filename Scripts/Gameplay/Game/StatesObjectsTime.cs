using Gameplay;
using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class StatesObjectsTime : MonoCached
    {
        [SerializeField] private GameObject _parentDayObjects;
        [SerializeField] private GameObject _parentNightObjects;
        [SerializeField] private TimeOfDay _time;

        protected override void OnEnable()
        {
            if (_parentDayObjects == null ||
                _parentNightObjects == null ||
                _time == null)
                throw new Exception();

            base.OnEnable();

            _time.OnDay += ActiveDayObjects;
            _time.OnNight += ActiveNightObjects;
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            _time.OnDay -= ActiveDayObjects;
            _time.OnNight -= ActiveNightObjects;
        }

        private void ActiveNightObjects()
        {
            _parentDayObjects.SetActive(false);
            _parentNightObjects.SetActive(true);
        }

        private void ActiveDayObjects()
        {
            _parentDayObjects.SetActive(true);
            _parentNightObjects.SetActive(false);
        }
    }
}