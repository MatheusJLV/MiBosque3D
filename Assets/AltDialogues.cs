using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltDialogues : MonoBehaviour
{
    public Dialogue[] dialogue;
    public int actual = 0;
    public void switchDialogues()
    {
        this.GetComponent<DialogueTrigger>().dialogue = dialogue[actual];
        actual++;
        if(actual>=dialogue.Length)
        {
            actual = 0;
        }
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
