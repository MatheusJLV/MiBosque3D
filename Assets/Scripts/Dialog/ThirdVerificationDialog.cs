using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdVerificationDialog : Desafio
{
    public GameObject challenge;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Nest.home)
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
