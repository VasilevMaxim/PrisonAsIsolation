public interface ILoader
{
    T Parse<T>(string textObj);
    string[] Load(string path, string id);
    void Save(ISaveable obj, string path);
}