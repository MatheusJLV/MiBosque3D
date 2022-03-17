using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall_trig_activate : MonoBehaviour
{
   public GameObject[] objetos;


    private void OnTriggerEnter(Collider other)
    {
        foreach (GameObject objeto in objetos)
        {
            objeto.SetActive(true);
        }
    }
}
