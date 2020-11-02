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

        internal override Storage Storage => _storage;
        private Storage _storage;

        // Components inspector.
        [SerializeField] private PlayerSettings _settings;
        [SerializeField] private TimeOfDay _time;

        protected override CharacterFacade Facade => _facade;
        private CharacterFacade _facade;

        private PlayerInteraction _interaction;
        private InputData _input;
        private Vector3 _startPosition;
        
        protected override void Initialize(IControl control, IMoveable moveable, IAnimatableCharacter animatable)
        {
            _facade = new CharacterFacade(control, moveable, animatable);
            _storage = new Storage(_settings.Storage.Size);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            _input = new InputData();

            _interaction = new PlayerInteraction(_input.Player.Interaction);
            var control = new InputControl(_input.Player.Move);
            var move = new MoveTranslate(control, transform, _settings.Speed);
            var animation = new AnimationCharacter(control, _animator, _settings.NamesAnimations);

            Initialize(control, move, animation);

            _input.Enable();

            _time.OnDay += RelocateStartPosition;
            _time.OnNight += RelocateStartPosition;
        }
        protected override void OnDisable()
        {
            base.OnDisable();
            _input.Disable();

            _time.OnDay -= RelocateStartPosition;
            _time.OnNight -= RelocateStartPosition;
        }

        private void RelocateStartPosition() =>
            transform.position = _startPosition;


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