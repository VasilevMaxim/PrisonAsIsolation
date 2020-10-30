using System;
using UnityEngine;

namespace Gameplay.Characters.SubSystems
{
    internal interface IManagement
    {
        event Action Start;
        event Action Cancel;
        bool IsActive { get; }
        Vector2 Direction { get; }
    }
}