using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autodestr : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objetivo;
    public void start()
    {
        destruir();
    }
        public void destruir()
    {
        Debug.Log("bye");
        Destroy(objetivo);
    }
}
