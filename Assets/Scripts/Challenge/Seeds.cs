using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{

    public int id;
    public Animator semillasAnim;
    bool entregada=false;

    private void OnMouseDown()
    {
        if (!entregada)
        {
            entregada=true;
            GameManager.instance.mochila.TestAddF(id);
            semillasAnim.SetTrigger("NuevaSemilla");
        }
    }
}
