using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Text _seconds;

    public void SetSecond(int second)
    {
        _seconds.text = second.ToString();
    }
}
