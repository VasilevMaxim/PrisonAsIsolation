using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintView : MonoBehaviour
{
    [SerializeField] private Text _hintText;
    [SerializeField] private Text _pressFText;

    [SerializeField] private string _notPossible;
    [SerializeField] private string _received;
    [SerializeField] private string _transferred;

    public void Transfer()
    {
        StartCoroutine(ShowDelay(_transferred));
    }

    public void NotPossible()
    {
        StartCoroutine(ShowDelay(_notPossible));
    }

    public void Receive()
    {
        StartCoroutine(ShowDelay(_received));
    }

    public void PressF(bool state)
    {
        _pressFText.gameObject.SetActive(state);
    }

    private IEnumerator ShowDelay(string text)
    {
        _hintText.text = text;
        yield return new WaitForSeconds(2f);
        _hintText.text = "";
    }

}
