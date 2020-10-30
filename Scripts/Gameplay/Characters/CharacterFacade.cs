using Gameplay.Characters.SubSystems;

namespace Gameplay.Characters
{
    internal class CharacterFacade : IUpdate, IFixedUpdate
    {
        internal IMoveable _moveable;
        internal IAnimatableCharacter _animatable;

        internal CharacterFacade(IMoveable moveable, IAnimatableCharacter animatable)
        {
            _moveable = moveable;
            _animatable = animatable;
        }

        public void FixedUpdate()
        {
            _moveable.Move();
        }

        public void Update()
        {
            _animatable.MoveAnimate();
        }
    }
}