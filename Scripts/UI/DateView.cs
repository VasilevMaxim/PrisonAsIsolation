using System;
using UnityEngine;
using UnityEngine.UI;

public class DateView : MonoBehaviour
{
    [SerializeField] private Text _date;
    [SerializeField] private Text _time;

    public void SetDate(DateTime date)
    {
        _date.text = date.ToShortDateString();
        _time.text = date.ToLongTimeString();
    }
}
