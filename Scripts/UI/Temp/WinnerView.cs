using UnityEngine;

public class WinnerView : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
