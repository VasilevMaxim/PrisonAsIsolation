using Gameplay.Characters.SubSystems;
using Gameplay.Items;
using Settings.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Characters
{
    [RequireComponent(typeof(CapsuleCollider2D))]
    internal class Police : Character
    {
        [SerializeField] private CharacterSettings _settings;
        [SerializeField] private Paths _paths;
        [SerializeField] private EnemyDetectable _zone;

        internal override Storage Storage => _storage;
        private Storage _storage;

        protected override CharacterFacade Facade => _facade;
        private CharacterFacade _facade;

        protected override void Initialize(IControl control, IMoveable moveable, IAnimatableCharacter animatable)
        {
            _facade = new CharacterFacade(control, moveable, animatable);
            _storage = new Storage(_settings.Storage.Size);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            var control = new AIControl(new TrafficRoute(transform, _paths), _zone);
            var move = new MoveTranslate(control, transform, 1);
            var animation = new AnimationCharacter(control, _animator, _settings.NamesAnimations);

            Initialize(control, move, animation);
        }
    }
}