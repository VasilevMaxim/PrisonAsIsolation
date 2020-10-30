using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ResourcesDataBase",
   menuName = "Settings/Items/ResourcesDataBase")]
public class ResourcesDataBase : ScriptableObject
{
    [SerializeField] private List<PairIdSprite> _base;

    public Sprite GetSprite(int id)
    {
        return _base.Find((element) => element.Id == id).Image;
    }
}
