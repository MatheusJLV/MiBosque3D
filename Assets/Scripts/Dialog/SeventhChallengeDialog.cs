using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SeventhChallengeDialog : Desafio
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameObject.GetComponent<BoxCollider>().enabled = false;
            ChallengePass7.inicio = System.DateTime.Now;
            IntroductionDialog();
        }
    }
}
