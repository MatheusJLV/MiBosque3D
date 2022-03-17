using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParkourMovement : MonoBehaviour
{
    MovableObject barco;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            MontarBarco();
        }

        if (barco != null && barco.IsFinished())
        {
            // gravity = -20.81f;
            // DESBLOQUEAR CONTROLES
            Debug.Log("Termino recorrido");
        }

    }

    void MontarBarco()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            barco = hit.transform.GetComponent<MovableObject>();
            if (barco != null)
            {
                barco.ActiveMovement(transform);
                /*gravity = 0f;*/
                // BLOQUEAR CONTROLES
                Debug.Log("Comienza recorrido");
            }

        }
    }
}
