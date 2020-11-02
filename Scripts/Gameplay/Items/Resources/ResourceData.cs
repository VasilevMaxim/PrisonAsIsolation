using System;
using UnityEngine;

[Serializable]
public struct ResourceData
{
    public int Id => _id;
    // To save, no more.
    [SerializeField] private int _id;
    
    internal ResourceData(int id)
    {
        _id = id;
    }

    internal static ResourceData Null => new ResourceData(0);

    public static bool operator ==(ResourceData resource1, ResourceData resource2)
    {
        return resource1._id == resource2._id;
    }
    public static bool operator !=(ResourceData resource1, ResourceData resource2)
    {
        return !(resource1 == resource2);
    }

    public override bool Equals(object obj)
    {
        if (obj is ResourceData == false) 
            return false;

        return this == (ResourceData) obj;
    }
    public override int GetHashCode()
    {
        return _id.GetHashCode();
    }
}
