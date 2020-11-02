using System;
using System.Collections.Generic;
using UnityEngine;

internal class Path : MonoCached
{
    [SerializeField] private List<Transform> _points;

    internal bool IsLastPoint(Vector2 currentPoint, bool inversion = false)
    {
        var indexCurrent = _points.FindIndex((point) => (Vector2) point.position == currentPoint);
        var numberCompare = inversion ? 0 : _points.Count - 1;
        return indexCurrent == numberCompare;
    }

    internal Vector2 GetNextPoint(Vector2 currentPoint, bool inversion = false)
    {
        var indexCurrent = _points.FindIndex((point) => (Vector2) point.position == currentPoint);
        var numberCompare = inversion ? 0 : _points.Count - 1;

        if (indexCurrent == numberCompare)
            throw new ArgumentException();

        indexCurrent += inversion ? -1 : 1;
        return _points[indexCurrent].position;
    }

    internal Vector2 GetFirstPoint()
    {
        return _points[0].position;
    }

    private void OnDrawGizmos()
    {
        if (_points.Count < 2)
            return;

        Gizmos.color = Color.red;

        for (int i = 1; i < _points.Count; i++)
            if (_points[i] != null && _points[i - 1] != null)
            Gizmos.DrawLine(_points[i - 1].position, _points[i].position);
    }
}
