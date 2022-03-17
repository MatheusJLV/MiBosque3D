using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondChallengeDialog : Desafio
{
    private GameObject[] interactables;

    public override void Start()
    {
        base.Start();
        interactables = GameObject.FindGameObjectsWithTag("Paper");
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            foreach (GameObject g in interactables)
            {
                g.GetComponent<ClicPaper>().active = true;
            }

            IntroductionDialog();
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }
}
