using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerrar : MonoBehaviour
{
    public GameObject objetivo;
    public GameObject principal;
    public GameObject secundario;
    public GameObject terceareo;
    public GameObject cuaternario;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Cerrar()
    {
        objetivo.SetActive(false);
        try
        {
            terceareo.SetActive(true);
            principal.SetActive(true);
            secundario.SetActive(false);
        }
        catch (Exception e)
        {
        }
        try
        {
            cuaternario.SetActive(true);
        }
        catch (Exception e)
        {
        }



    }
}
