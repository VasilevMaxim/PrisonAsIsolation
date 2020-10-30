using UnityEngine;

namespace Settings.Character
{
    [CreateAssetMenu(fileName = "CharacterSettings",
      menuName = "Settings/Characters/PlayerSettings")]
    public class PlayerSettings : CharacterSettings
    {
        public ResourcesDataBase Resources => _resources;
        [SerializeField] private ResourcesDataBase _resources;
    }
}