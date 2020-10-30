using UnityEngine;
using UnityEngine.SceneManagement;

// Дописывал в последние 2 часа, пропустите, пожалуйста, скрипт. Спасибо.
// В ближайший коммит все исправлю.

public class DefeatView : MonoBehaviour
{
    [SerializeField] private GameObject _parentDefeat;
    [SerializeField] private string _nameSceneFirst;

    public void Defeat()
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
