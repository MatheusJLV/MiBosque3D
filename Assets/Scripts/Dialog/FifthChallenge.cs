using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FifthChallenge : Desafio
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ChallengePass5.inicio = System.DateTime.Now;
            gameObject.GetComponent<BoxCollider>().enabled = false;

            IntroductionDialog();

        }
    }
}
