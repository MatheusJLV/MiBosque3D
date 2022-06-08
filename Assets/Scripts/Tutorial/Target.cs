using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update


    void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {  
            Destroy(transform.parent.gameObject);
        }
    }
}
