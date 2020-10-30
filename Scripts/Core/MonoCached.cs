using UnityEngine;

//https://www.youtube.com/watch?v=7kHNUdNHT-A
/// <summary>
/// Quick update.
/// </summary>
public abstract class MonoCached : MonoBehaviour
{
    /// <summary>
    /// Analogue Update.
    /// </summary>
    public virtual void Tick()
    {

    }

    /// <summary>
    /// Analogue FixedUpdate.
    /// </summary>
    public virtual void TickFixed()
    {

    }

    /// <summary>
    /// Be sure to write base.OnEnable().
    /// </summary>
    protected virtual void OnEnable()
    {
        TickUpdate.Add(this);
        TickFixedUpdate.Add(this);
    }

    /// <summary>
    /// Be sure to write base.OnDisable().
    /// </summary>
    protected virtual void OnDisable()
    {
        TickUpdate.Remove(this);
        TickFixedUpdate.Remove(this);
    }
}