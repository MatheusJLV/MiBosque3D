using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoTutorial : MonoBehaviour
{
    public GameObject TM;

    public void OnTriggerEnter(Collider other)
    {
      
        Debug.Log("algo entro");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("player entro");
            //TM.GetComponent<TargetManager>().GoForIt = true;
        }
    }
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
