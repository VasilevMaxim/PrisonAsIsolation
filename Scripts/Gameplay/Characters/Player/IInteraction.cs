using System;

namespace Gameplay.Characters.SubSystems
{
    internal interface IInteraction
    {
        Action<IInteractable> ActionDelayed { set; }
    }
}