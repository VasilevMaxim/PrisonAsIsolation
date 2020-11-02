using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// It is used to print text as if on a keyboard.
/// </summary>
[RequireComponent(typeof(Text))]
internal class TextPrint : MonoBehaviour
{
    [SerializeField] private UnityEvent _exitWrite;

    [SerializeField] private string _nameSceneLoad;
    [SerializeField] private float _periodPrint;
    [SerializeField] private float _timeDelayAfterText;

    [Space]
    [SerializeField] private Text _text;

    private void OnEnable()
    {
        StartCoroutine(Print());
    }

    private IEnumerator Print()
    {
        string text = _text.text;
        _text.text = "";
        for(int i = 0; i < text.Length; i++)
        { 
            yield return new WaitForSeconds(_periodPrint);
            _text.text += text[i];
        }

        _exitWrite.Invoke();
        yield return new WaitForSeconds(_timeDelayAfterText);
        SceneManager.LoadSceneAsync(_nameSceneLoad);
    }
}
