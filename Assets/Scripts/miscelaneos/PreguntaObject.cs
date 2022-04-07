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
public class PreguntaObjectOriginal
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

[System.Serializable]
public class GameLevelsChallenges
{
    public int GameLevelId;
    public string updatedAt;
}
[System.Serializable]
public class Option
{
    public int ChallengeOptionId;
    public string codename;
    public bool correctOption;
    public string text;
    public string image;
    public string updatedAt;
}
[System.Serializable]
public class Feedback
{
    public int ChallengeFeedbackId;
    public string feedback;
    public string image;
    public string updatedAt;
}

[System.Serializable]
public class PreguntaObject
{
    public int ChallengeID;
    public string codename;
    public string question;
    public int score;
    public string image;
    public int difficulty;
    public string updatedAt;
    public GameLevelsChallenges[] gameLevelsChallenges;
    public Option[] options;
    public Feedback feedback;
}