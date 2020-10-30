using Gameplay.Characters.SubSystems;

namespace Gameplay.Characters
{
    internal interface IInteractable
    {
        IInteraction Interaction { get; }
    }
}