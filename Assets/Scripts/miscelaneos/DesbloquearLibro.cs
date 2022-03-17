using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesbloquearLibro : MonoBehaviour
{
    //private bool active = false;
    // Start is called before the first frame update

    public void LibroActivo()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<ShowBook>().enabled = true;
    }

}