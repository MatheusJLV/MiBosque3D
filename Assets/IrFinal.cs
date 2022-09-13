using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrFinal : MonoBehaviour
{
    //public GameObject finalChallenge;
    public void OnMouseDown()    
    //public void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        {
            Debug.Log("clic a final");
            SceneManager.LoadScene("Final");
            //finalChallenge.GetComponent<ChallengePass5>().cambio_a_final();
        }
    }
    public void irFinal()
    {
        SceneManager.LoadScene("Final");
    }
}
