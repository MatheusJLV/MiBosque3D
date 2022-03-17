using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ThirdChallenge : MonoBehaviour
{
    public ChallengePass3 passScript;
    /*public override void Start()
    {
        base.Start();
    }*/
    public void ActivarTercerDesafío()
    {
        ChallengePass3.inicio = System.DateTime.Now;
        Debug.Log("Se ha activado el tercer desafío");
        Squirrel.activate = true;
        passScript.sendStartReq();
    }
    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameObject.GetComponent<BoxCollider>().enabled = false;
            Squirrel.activate = true;

            IntroductionDialog();
        }
    }*/
}
