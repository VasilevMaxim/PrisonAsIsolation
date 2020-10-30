using System.Collections.Generic;
using UnityEngine;

internal class Paths : MonoCached
{
    [SerializeField] private List<Path> _paths;

    internal void Add(Path path)
    {
        _paths.Add(path);
    }
    internal void Remove(Path path)
    {
        _paths.Remove(path);
    }

    internal Path GetRandomPath()
    {
        return _paths[UnityEngine.Random.Range(0, _paths.Count)];
    }
}
