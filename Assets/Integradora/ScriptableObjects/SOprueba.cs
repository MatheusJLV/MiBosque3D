using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable Objects/SOprueba")]
public class SOprueba : ScriptableObject
{
    public string nombre;
    
    public void saludar()
    {
        Debug.Log("hola");
    }
}
