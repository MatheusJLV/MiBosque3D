using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa_script : MonoBehaviour
{
    public GameObject btnGuardarDiploma;
    // Start is called before the first frame update
    void Start()
    {
        if (Player.instance.playerData.finishedGame)
        {
            btnGuardarDiploma.SetActive(true);
        }
        else
        {
            btnGuardarDiploma.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
