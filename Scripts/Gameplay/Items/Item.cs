using UnityEngine;
using System;
using Gameplay.Characters;
using Interface;

namespace Gameplay.Items
{
    internal abstract class Item : MonoCached
    {      
        internal abstract void Interaction(IInteractable interactable);

        public int Id => _id;
        [SerializeField] private int _id;
        [SerializeField] protected HintView _hint;

        protected virtual void OnTriggerEnter2D(Collider2D obj)
        {
            Action(obj, true);
        }
       
        protected virtual void OnTriggerExit2D(Collider2D obj)
        {
            Action(obj, false);
        }

        protected void Action(Collider2D collider, bool isOpenAccess)
        {
            var interactable = collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (isOpenAccess == true)
                    interactable.Interaction.ActionDelayed = (IInteractable ins) => Interaction(ins);
                else
                    interactable.Interaction.ActionDelayed = null;
            }
        }
    }
}