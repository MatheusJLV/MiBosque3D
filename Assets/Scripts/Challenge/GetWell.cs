
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWell : MonoBehaviour
{
    public GameObject panelwater;
    public GameObject panelbalde;
    public Text time;
    public Text recordatorio;

    private void OnMouseDown()
    {
        if (time.text != "0" && (panelbalde.activeSelf == true) && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            
            recordatorio.text = "El pozo esta cerrado, busca el lago";
            
        }
        else if (time.text != "0" && (panelbalde.activeSelf == false) && (panelwater.activeSelf == false) && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            recordatorio.text = "Busca algo en que llevar agua!";
        }


    }
}