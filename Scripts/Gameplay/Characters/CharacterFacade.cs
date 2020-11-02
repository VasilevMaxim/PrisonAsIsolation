using Gameplay.Characters.SubSystems;

namespace Gameplay.Characters
{
    public class CharacterFacade : IUpdate, IFixedUpdate
    {
        internal IMoveable _moveable;
        internal IAnimatableCharacter _animatable;
        internal IControl _control;

        internal CharacterFacade(IControl control, IMoveable moveable, IAnimatableCharacter animatable)
        {
            _control = control;
            _moveable = moveable;
            _animatable = animatable;
        }

        public void FixedUpdate()
        {
            _moveable.Move();
        }

        public void Update()
        {
            _control.Check();
            _animatable.MoveAnimate();
        }
    }
}