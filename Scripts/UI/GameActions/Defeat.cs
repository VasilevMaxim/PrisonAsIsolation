using UnityEngine;
using UnityEngine.SceneManagement;

public class Defeat : MonoBehaviour
{
    [SerializeField] private GameObject _parentDefeat;
    [SerializeField] private string _nameSceneFirst;

    public void OnDefeat()
    {
        Time.timeScale = 0;
        _parentDefeat.SetActive(true);
    }

    public void LoadFirstScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(_nameSceneFirst);
    }
}
