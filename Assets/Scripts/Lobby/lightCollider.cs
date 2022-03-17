using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCollider : MonoBehaviour
{

    // Update is called once per frame
 

    void OnTriggerEnter(Collider  other)
    {

        if (other.tag=="Player")
        {
            Debug.Log(other.name);
        }
       
        
    }
}
