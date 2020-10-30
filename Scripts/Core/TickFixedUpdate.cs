using System.Collections.Generic;

/// <summary>
/// The only FixedUpdate.
/// </summary>
public class TickFixedUpdate : TickBase
{
    protected static List<MonoCached> _objects = new List<MonoCached>(0);

    public static void Add(MonoCached obj)
    {
        _objects.Add(obj);
    }
    public static void Remove(MonoCached obj)
    {
        _objects.Remove(obj);
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _objects.Count; i++)
            _objects[i].TickFixed();
    }
}
