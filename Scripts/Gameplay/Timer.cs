using System.Collections;
using UnityEngine;

public class Timer : MonoCached
{
    private uint _time;
    private uint Time
    {
        set
        {
            _time = value;
            _view.SetSecond((int)_time);
        }
        get => _time;
    }
    [SerializeField] private uint _timeDay;
    [SerializeField] private TimerView _view;
    [SerializeField] private Date _date;

    protected override void OnEnable()
    {
        base.OnEnable();
        Time = _timeDay;
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        while (Time-- > 0)
            yield return new WaitForSeconds(1f);

        _date.Reload();
        Time = _timeDay;

        gameObject.SetActive(false);
        gameObject.SetActive(true);
    }
}
