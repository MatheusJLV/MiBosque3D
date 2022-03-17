using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FourthChallenge : MonoBehaviour
{
    public PickupObject hamsterCage;
    public ChallengePass4 passScript;

    public void ActivateFourthChallenge()
    {
        ChallengePass4.inicio = System.DateTime.Now;
        passScript.sendStartReq();
        hamsterCage.OnActivateFourthChallenge();
        GameObject[] recolectables = GameObject.FindGameObjectsWithTag("Pick");
        foreach (GameObject g in recolectables)
        {
            g.GetComponent<Pick>().activate = true;
        }
        //GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BarChallenge>().instruction.text = "Encuentra ratones o salamandras";
    }
}
