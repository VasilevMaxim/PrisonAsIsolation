using UnityEngine;

/// <summary>
/// Temporary class.
/// </summary>
internal class BackgroundDisable : MonoBehaviour
{
    [SerializeField] private Animation _disableAnimation;

    private void OnEnable()
    {
        Disable();
    }

    public void Disable()
    {
        _disableAnimation.Play();
    }
}
