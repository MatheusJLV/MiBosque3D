using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MochilaCtrl : MonoBehaviour
{
    bool semilla, basura = true;
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
    public void Desnotificar()
    {
        Debug.Log("desnotificar: "+ new Color(0, 0, 0, .4f));
        this.GetComponent<Image>().color = new Color(0, 0, 0, .4f);
    }
    public void Notificar(string notif)
    {
        /*bool nuevo = false;
        if (notif== "basura")
        {
            if(basura)
            {
                nuevo = true;
                basura = false;
            }
        }
        else if(notif == "semilla")
        {
            if (semilla)
            {
                nuevo = true;
                semilla = false;
            }
        }
        if (nuevo)*/
        {
            Debug.Log("notificar: " + new Color(37, 255, 18, .4f));
            this.GetComponent<Image>().color = new Color(37, 250, 18, .4f);
        }
        /*else
        {
            Debug.Log("notificar: " + new Color(13, 159, 0, .4f));
            this.GetComponent<Image>().color = new Color(13, 159, 0, .4f);
        }*/
        
    }
}
