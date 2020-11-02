using System;
namespace Gameplay.Characters.SubSystems
{
    internal interface IDetectable
    {
        Action<Character> Detect { set; }
    }
}