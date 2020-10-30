using UnityEngine;
using System;
using Gameplay.Characters;

namespace Gameplay.Items
{
    internal abstract class Item : MonoCached
    {
        public int Id => _id;
        [SerializeField] private int _id;

        [SerializeField] protected HintView _hint;

        internal abstract void Interaction(Character character);
        
        protected virtual void OnTriggerEnter2D(Collider2D obj)
        {
            Action(obj, true);
        }
       
        protected virtual void OnTriggerExit2D(Collider2D obj)
        {
            Action(obj, false);
        }

        protected void Action(Collider2D obj,  bool isOpenAccess)
        {
            var character = obj.GetComponent<IInteractable>();
            if (character != null)
            {
                if (isOpenAccess == true)
                {
                    character.Interaction.OpenAccess();
                    character.Interaction.ActionDelayed = Interaction;
                }
                else
                {
                    character.Interaction.ExitAccess();
                    character.Interaction.ActionDelayed = null;
                }
            }
        }
    }
}