using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
internal class TextPrint : MonoBehaviour
{
    [SerializeField] private UnityEvent _exitWrite;
    [SerializeField] private string _nameSceneLoad;
    [SerializeField] private float _period;
    [SerializeField] private float _timeDelayAfterText;

    private Text _text;

    private void OnEnable()
    {
        _text = GetComponent<Text>();
        StartCoroutine(Print());
    }

    private IEnumerator Print()
    {
        string text = _text.text;
        _text.text = "";
        for(int i = 0; i < text.Length; i++)
        { 
            yield return new WaitForSeconds(_period);
            _text.text += text[i];
        }

        _exitWrite.Invoke();
        yield return new WaitForSeconds(_timeDelayAfterText);
        SceneManager.LoadSceneAsync(_nameSceneLoad);
    }
}
