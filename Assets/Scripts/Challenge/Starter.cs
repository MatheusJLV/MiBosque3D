using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starter : MonoBehaviour
{
    public GameObject timer;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            gameObject.GetComponent<BoxCollider>().enabled = false;
            timer.SetActive(true);
            Destroy(this.gameObject);

        }
    }


}
