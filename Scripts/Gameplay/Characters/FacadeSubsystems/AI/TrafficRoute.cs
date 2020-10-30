using UnityEngine;

internal class TrafficRoute : ITrafficRoute
{
    private const float DistanceAction = 0.08f;
    
    public Vector2 Direction
    {
        get
        {
            if (Vector2.Distance(_transform.position, _currentPoint) < DistanceAction)
            {
                if (_currentPath.IsLastPoint(_currentPoint, _inversion))
                    _inversion = !_inversion;

                _currentPoint = _currentPath.GetNextPoint(_currentPoint, _inversion);

                _direction = _currentPoint - (Vector2)_transform.position;
                _direction = GetNormaledMaxAxis(_direction);
                return _direction;
            }

            return _direction;
        }
    }
    private Vector2 _direction;

    private readonly Paths _paths;
    private readonly Transform _transform;

    private Path _currentPath;
    private Vector2 _currentPoint;
    private bool _inversion;

    internal TrafficRoute(Transform transform, Paths paths)
    {
        _paths = paths;
        _transform = transform;

        _currentPath = _paths.GetRandomPath();
        _currentPoint = _currentPath.GetFirstPoint();
        _direction = GetNormaledMaxAxis(_currentPoint - (Vector2)_transform.position);
    }

    private Vector2 GetNormaledMaxAxis(Vector2 value)
    {
        var normal = value.normalized;

        if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
            return new Vector2(Round(normal.x), 0);

        return new Vector2(0, Round(normal.y));
    }

    private float Round(float value)
    {
        if (value < 0)
            return Mathf.Floor(value);
        return Mathf.Ceil(value);
    }
}
    