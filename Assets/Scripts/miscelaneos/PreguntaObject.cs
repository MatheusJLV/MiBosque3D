using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonHelper
{
    public static T[] GetJsonArray<T>(string json)
    {
        string newJson = "{\"array\": " + json + "}";
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array = null;
    }
    
}

[System.Serializable]
public class PreguntaObject
{
    public int Id;
    public string ImageAddress;
    public string Text;
    public List<string> Options;
    public int Answer;
    public string Feedback;
    public List<int> Stations;
    public string Category;
    public string Difficulty;
    public int OA;
    public List<string> Gallery;
}