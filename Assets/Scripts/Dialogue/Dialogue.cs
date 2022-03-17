using UnityEngine;

[System.Serializable]
public class Dialogue{
    [TextArea(2,4)]
    public string[] title;
    [TextArea(3,10)]
    public string[] sentences;
    public Sprite[] sprites;

}