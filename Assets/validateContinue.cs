using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class validateContinue : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] listaActivar;
    public GameObject[] listaDesctivar;
    public int fase = 0;
    public GameObject menuController;
    /*void Start()
    {
        
    }*/
    public void validar(int x)
    {
        bool validez=menuController.GetComponent<MenuController>().validar(x);
        if (validez)
        {
            foreach (GameObject go in listaActivar)
            {
                go.SetActive(true);
            }
            foreach (GameObject go in listaDesctivar)
            {
                go.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
