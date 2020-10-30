using UnityEngine;

internal class Info : MonoBehaviour
{
    [SerializeField] private GameObject _developers;
    public void ShowDevelopers()
    {
        _developers.SetActive(!_developers.activeInHierarchy);
    }
}
