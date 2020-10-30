using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public class Loader : ILoader
{
    private const string Separator = "|";

    public T Parse<T>(string textObj)
    {
        return JsonUtility.FromJson<T>(textObj);
    }

    public string[] Load(string path, string id)
    {
        if (File.Exists(path) == false)
            throw new FileLoadException();

        using (FileStream fstream = File.OpenRead(path))
        {
            byte[] dataSet = new byte[fstream.Length];
            fstream.Read(dataSet, 0, dataSet.Length);
            var dataSetText = Encoding.Default.GetString(dataSet);
            var textes = dataSetText.Split(Separator.ToCharArray());
            var prefix = "id " + id;
            
            bool isContains = false;
            List<string> rezult = new List<string>(0);
            foreach (var text in textes)
            {
                if (isContains == true)
                {
                    var isId = text.Contains("id ");
                    if (isId == true)
                        break;

                    rezult.Add(text);
                    continue;
                }
                isContains = text.Contains(prefix);
            }

            return rezult.ToArray();
        }
    }

    public void Save(ISaveable saveable, string path)
    {
        var prefix = "id " + saveable.GetType().ToString() + Separator;
        var dataObjs = saveable.GetSaveObjects();
        var dataSet = dataObjs.Select(data => JsonUtility.ToJson(data) + Separator).ToList();
        dataSet.Insert(0, prefix);

        var lastString = dataSet[dataSet.Count - 1];
        dataSet[dataSet.Count - 1] = lastString.Substring(0, lastString.Length - 1);

        WriteText(path, dataSet);
    }

    private void WriteText(string path, IEnumerable<string> texts)
    {
        var dataSet = texts.Select(text => Encoding.Default.GetBytes(text)).ToList();
        using (FileStream fstream = new FileStream(path, FileMode.Append))
        {
            dataSet.ForEach(data => fstream.Write(data, 0, data.Length));
        }
    }

    public void DeleteSave(string path)
    {
        File.Delete(path);
    }
}
