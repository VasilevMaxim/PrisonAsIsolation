using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderSceneGame : MonoBehaviour
{
    [SerializeField] private string _nameSceneGame;
    private void OnEnable()
    {
        SceneManager.LoadSceneAsync(_nameSceneGame);
    }
}
