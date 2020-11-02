using System;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    public interface IControl
    {
        event Action Start, Cancel;
        bool IsActive { get; }
        Vector2 Direction { get; }
        void Check();
    }
}