using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FifthVerificationDialog : Desafio
{

    public GameObject g5;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            if (g5.activeSelf)
            {
                
                IntroductionDialog(0);

            }
            else
            {
                IntroductionDialog(1);
            }

        }
    }
}
