using Gameplay.Characters;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ZoneWinner : MonoBehaviour
{
    private const string WinName = "Win";

    [SerializeField] private UnityEvent _win;
    [SerializeField] private Animator _animatorPlayer;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        var player = obj.GetComponent<Player>();
        if (player != null)
            Win();
    }

    private void Win()
    {
        _win.Invoke();
        _animatorPlayer.SetBool(WinName, true);
    }
}
