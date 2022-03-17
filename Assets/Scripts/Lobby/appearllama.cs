using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appearllama : MonoBehaviour
{
    
    public GameObject llama;
    public int show = 5;
    int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        activellama();
    }

    void activellama()
    {
        if(show == randomNumber)
        {
            llama.SetActive(true);
        }
    }
}
