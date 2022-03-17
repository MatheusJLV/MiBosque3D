using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstChallenge : MonoBehaviour//Desafio
{
    public ChallengePass passScript;

    //private GameObject[] interactables;

    /*public override void Start()
    {
        base.Start();
        interactables = GameObject.FindGameObjectsWithTag("Clic");
    }
    
    
    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            foreach (GameObject g in interactables)
            {
                g.GetComponent<Clic>().activate = true;
            }

            IntroductionDialog();
            gameObject.GetComponent<Collider>().enabled = false;

            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BarChallenge>().instruction.text = "Interactua con especies";

        }
    }*/
    public void ActivateFirstChallenge()
    {
        GameObject[] interactables = GameObject.FindGameObjectsWithTag("Clic");
        Debug.Log("Primer Desafio Activado");
        ChallengePass.inicio = System.DateTime.Now;
        passScript.sendStartReq();
        foreach (GameObject g in interactables)
        {
            g.GetComponent<Clic>().activate = true;
        }
 

    }
}
