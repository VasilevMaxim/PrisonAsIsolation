using Gameplay.Characters.SubSystems;
using Gameplay.Items;
using System.Linq;
using UnityEngine;
using PlayerSettings = Settings.Character.PlayerSettings;

namespace Gameplay.Characters
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D))]
    internal class Player : Character, IInteractable
    {
        public IInteraction Interaction => _interaction;

        // Components inspector.
        [SerializeField] private PlayerSettings _settings;
        [SerializeField] private ItemView _itemView;
        [SerializeField] private HintView _hint;

        protected override CharacterFacade Facade => _facade;

        internal override Storage Storage => _storage;
        private Storage _storage;

        private CharacterFacade _facade;
        private PlayerInteraction _interaction;
        private InputData _input;

        protected override void Initialize(IMoveable moveable, IAnimatableCharacter animatable)
        {
            _facade = new CharacterFacade(moveable, animatable);
            _storage = new Storage(_settings.Storage.Size);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _input = new InputData();
            _interaction = new PlayerInteraction(_input.Player.Interaction, this, _hint);
            var management = new InputManagement(_input.Player.Move);
            var move = new MoveTranslate(management, transform, _settings.Speed);
            var animation = new AnimationCharacter(management, _animator, _settings.NamesAnimations);

            Initialize(move, animation);

            _input.Enable();

            Storage.Change += StorageChange;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            _input.Disable();
        }

        private void StorageChange(ResourceData[] resources)
        {
            var sprites = resources.Select(resource => _settings.Resources.GetSprite(resource.Id));
            _itemView.SetItems(sprites);
        }


        // A save might look like this. Implement the interface ISaveable
        /*
         public object[] GetSaveObjects()
         {
             var saveObjs = new object[2];
             saveObjs[0] = transform.position;
             saveObjs[1] = Storage;
             return saveObjs;
         }

         public void Load(IReadOnlyList<string> objs, ILoader loader)
         {
             transform.position = loader.Parse<Vector3>(objs[0]);
             Storage = loader.Parse<Storage>(objs[1]);
         }
        */
    }
}