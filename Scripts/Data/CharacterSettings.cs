using UnityEngine;

namespace Settings.Character
{
    [CreateAssetMenu(fileName = "CharacterSettings",
       menuName = "Settings/Characters/CharacterSettings")]
    public class CharacterSettings : ScriptableObject
    {
        public float Speed => _speed;
        public StorageSettings Storage => _storage;
        public NamesAnimationsCharacter NamesAnimations => _namesAnimations;

        [SerializeField] protected float _speed;
        [SerializeField] protected StorageSettings _storage;
        [SerializeField] protected NamesAnimationsCharacter _namesAnimations;
    }
}