using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Interface
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private List<Image> _images;
        [SerializeField] private ResourcesDataBase _resources;

        public void SetItems(IEnumerable<Sprite> sprites)
        {
            var spritesList = sprites.ToList();

            if (spritesList.Count > _images.Count)
                throw new ArgumentException();

            for (int i = 0; i < spritesList.Count; i++)
                _images[i].sprite = spritesList[i];
        }
    }
}