using UnityEngine;

[CreateAssetMenu(fileName = "NamesAnimationsCharacter", 
    menuName = "Settings/Animations/NamesAnimationsCharacter")]
public class NamesAnimationsCharacter : ScriptableObject
{
    public string X => _x;
    public string Y => _y;
    public string Interaction => _interaction;

    [SerializeField] private string _x;
    [SerializeField] private string _y;
    [SerializeField] private string _interaction;
}