using UnityEngine;
using System;

[Serializable]
internal class PairIdSprite
{
    public uint Id => _id;
    public Sprite Image => _image;

    [SerializeField] private uint _id;
    [SerializeField] private Sprite _image;
}
