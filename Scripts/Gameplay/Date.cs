using Gameplay.Characters;
using Gameplay.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Дописывал в последние 2 часа, пропустите, пожалуйста, скрипт. Спасибо.
// В ближайший коммит все исправлю.

public class Date : MonoCached
{
    [SerializeField] private DateView _view;
    
    [Range(1, 30)] [SerializeField] private int _day;
    [SerializeField] private Light _light;

    [SerializeField] private GameObject _parentDayObjects;
    [SerializeField] private GameObject _parentNightObjects;

    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _startPositionCamera;

    [SerializeField] private List<Door> _doors;
    [SerializeField] private AudioBackground _audioBackground;

    private DateTime _dateGame;
    private DateTime DateGame 
    { 
        get => _dateGame;     
        set
        {
            _dateGame = value;
            _view.SetDate(_dateGame);
        }
    
    }

    private Coroutine _timer;
    private bool _isNight = true;

    private void Awake()
    {
        DateGame = new DateTime(1967, 10, _day, 8, 3, 0);
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        Reload();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    public void Reload()
    {
        if(_timer != null)
            StopCoroutine(_timer);
        _timer = null;

        _isNight = !_isNight;
        _player.transform.position = _startPosition.position;
        _camera.transform.position = _startPositionCamera.position;

        if (_isNight == true)
        {
            _doors.ForEach(door => door.Open(false));
            DateGame = DateGame.AddDays(1);
            _parentDayObjects.SetActive(false);
            _parentNightObjects.SetActive(true);

            _audioBackground.OnAnger();

            _light.intensity = 0;
        }
        else
        {
            _audioBackground.OnDefault();

            _parentDayObjects.SetActive(true);
            _parentNightObjects.SetActive(false);
            _light.intensity = 1.3f;
        }

        _timer = StartCoroutine(Timer());
    }

    private IEnumerator Timer()
    {
        while (true)
        {
            DateGame = DateGame.AddSeconds(1);
            yield return new WaitForSeconds(1f);
        }
    }
}
