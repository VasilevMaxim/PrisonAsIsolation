using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
    public class HintView : MonoBehaviour
    {
        [SerializeField] private Text _hint;
        [SerializeField] private string _notPossible, _received, _transferred;

        public void Transfer() => Show(_transferred);
        public void NotPossible() => Show(_notPossible);
        public void Receive() => Show(_received);

        private void Show(string text)
        {
            StartCoroutine(ShowDelay(text));
        }

        private IEnumerator ShowDelay(string text)
        {
            _hint.text = text;
            yield return new WaitForSeconds(2f);
            _hint.text = "";
        }

    }
}