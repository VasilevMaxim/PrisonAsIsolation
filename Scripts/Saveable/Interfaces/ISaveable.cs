using System.Collections.Generic;

public interface ISaveable
{
    object[] GetSaveObjects();
    void Load(IReadOnlyList<string> objs, ILoader loader);
}