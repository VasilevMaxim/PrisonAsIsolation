using Gameplay.Characters.SubSystems;
using Gameplay.Items;
using UnityEngine;

namespace Gameplay.Characters
{
    /// <summary>
    /// Parent class for all characters in the game.
    /// </summary>
    [RequireComponent(typeof(CapsuleCollider2D))]
    public abstract class Character : MonoCached
    {
        // Components inspector.
        [SerializeField] protected Animator _animator;

        internal abstract Storage Storage { get; }

        // Components.
        protected Rigidbody2D _rigidbody;

        // Facade pattern.
        protected abstract CharacterFacade Facade { get; }
        protected abstract void Initialize(IControl control, 
                                           IMoveable moveable, 
                                           IAnimatableCharacter animatable);

        #region MonoBehaviour

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        #endregion

        public override void Tick()
        {
            Facade.Update();
        }
        public override void TickFixed()
        {
            Facade.FixedUpdate();
        }
    }
}
