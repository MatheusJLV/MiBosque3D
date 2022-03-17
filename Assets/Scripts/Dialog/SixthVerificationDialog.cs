using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SixthVerificationDialog : Desafio
{
    public GameObject challenge;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            if (DragNDrop.basura == 2)
            {
                disappear = true;
                imageCorrecto.SetActive(true);
                
                IntroductionDialog(0);
                
            }
            else
            {
                IntroductionDialog(1);
            }

        }
    }
}
