using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{

    public int id;
    public Animator semillasAnim;
    bool entregada=false;
    public GameObject padreSemillas;

    private void Start()
    {
        padreSemillas = GameObject.Find("SemillasAnim");        
    }

    private void OnMouseDown()
    {
        if (!entregada)
        {
            entregada=true;
            GameManager.instance.mochila.TestAddF(id);
            for (int i = 0; i < padreSemillas.transform.childCount; i++)
            {
                padreSemillas.transform.GetChild(i).gameObject.SetActive(false);
            }

            switch (id)
            {

                case 3:
                    //teca
                    padreSemillas.transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 4:
                    // ceibo
                    padreSemillas.transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 8:
                    // bototillo
                    padreSemillas.transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 9:
                    // judea
                    padreSemillas.transform.GetChild(4).gameObject.SetActive(true);
                    break;
                case 10:
                    // guayaca
                    padreSemillas.transform.GetChild(5).gameObject.SetActive(true);
                    break;
                case 11:
                    // jacaranda
                    padreSemillas.transform.GetChild(3).gameObject.SetActive(true);
                    break;
                default:
                    // otras semillas
                    break;
            }
            semillasAnim.SetTrigger("NuevaSemilla");
        }
    }
}
