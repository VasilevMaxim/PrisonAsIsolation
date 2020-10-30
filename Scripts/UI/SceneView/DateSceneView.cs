using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DateSceneView : MonoBehaviour
{
    [SerializeField] private DateView _view;
    [Range(1, 30)] [SerializeField] private int _day;

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

    protected  void OnEnable()
    {
        if (_timer != null)
            StopCoroutine(_timer);
        _timer = null;

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
