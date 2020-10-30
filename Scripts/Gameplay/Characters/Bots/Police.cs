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

        protected override void Initialize(IMoveable moveable, IAnimatableCharacter animatable)
        {
            _facade = new CharacterFacade(moveable, animatable);
            _storage = new Storage(_settings.Storage.Size);
        }

        protected override void OnEnable()
        {
            base.OnEnable();

            var management = new AIManagement(new TrafficRoute(transform, _paths), _zone);
            var move = new MoveTranslate(management, transform, 1);
            var animation = new AnimationCharacter(management, _animator, _settings.NamesAnimations);

            Initialize(move, animation);
        }
    }
}