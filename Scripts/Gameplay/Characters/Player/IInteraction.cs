using System;

namespace Gameplay.Characters.SubSystems
{
    internal interface IInteraction
    {
        Action<Character> ActionDelayed { set; }
        void OpenAccess();
        void ExitAccess();
    }
}