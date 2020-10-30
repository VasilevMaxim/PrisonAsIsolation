using UnityEngine;

namespace Settings.Character
{
    [CreateAssetMenu(fileName = "StorageSettings",
     menuName = "Settings/Items/StorageSettings")]
    public class StorageSettings : ScriptableObject
    {
        public int Size => (int)_sizeStorage;
        [SerializeField] private uint _sizeStorage;
    }
}