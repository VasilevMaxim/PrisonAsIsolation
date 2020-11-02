using System;
using UnityEngine;

namespace Gameplay
{
    public class AudioBackground : MonoCached
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioClip _anger, _default;
        [SerializeField] private TimeOfDay _time;

        protected override void OnEnable()
        {
            if (_source == null ||
                _anger == null ||
                _default == null ||
                _time == null)
                throw new Exception();

            base.OnEnable();
           
            _time.OnDay += OnDefault;
            _time.OnNight += OnAnger;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            _time.OnDay -= OnDefault;
            _time.OnNight -= OnAnger;
        }

        private void OnAnger()
        {
            _source.clip = _anger;
            _source.Play();
        }

        private void OnDefault()
        {
            _source.clip = _default;
            _source.Play();
        }
    }
}