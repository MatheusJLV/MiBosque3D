using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectionStation : MonoBehaviour
{
    public Text ts;
    public string ns;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("antes " + ts.text);
        Debug.Log("valor: " + ns);
        ts.text = ns;
        Debug.Log("despues " + ts.text);
    }
}
