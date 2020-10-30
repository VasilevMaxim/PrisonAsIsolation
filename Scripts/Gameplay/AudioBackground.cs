using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBackground : MonoCached
{
    [SerializeField] private AudioClip _anger;
    [SerializeField] private AudioClip _default;
    [SerializeField] private AudioSource _source;

    public void OnAnger()
    {
        _source.clip = _anger;
        _source.Play();
    }

    public void OnDefault()
    {
        _source.clip = _default;
        _source.Play();
    }
}
