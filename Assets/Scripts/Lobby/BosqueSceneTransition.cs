using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BosqueSceneTransition : MonoBehaviour
{
    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    public void transition()
    {
        player.transform.position += new Vector3(-28.6f, 0, 0);
        
        

    }

}
