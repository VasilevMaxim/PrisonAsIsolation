using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoCached
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    private float _positionZEnable;

    protected override void OnEnable()
    {
        base.OnEnable();
        _positionZEnable = transform.position.z;
    }

    public override void Tick()
    {
        if (_target == null)
            return;

        transform.position = Follow();
        ResetAxisZ();
    }

    private Vector2 Follow()
    {
       return Vector2.Lerp(transform.position, _target.position, Time.deltaTime * _speed);
    }
    private void ResetAxisZ()
    {
        var position = transform.position;
        transform.position = new Vector3(
            position.x,
            position.y, 
            _positionZEnable);
    }
}
