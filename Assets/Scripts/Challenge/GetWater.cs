using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetWater : MonoBehaviour
{
    public GameObject panelwater;
    public GameObject panelbalde;
    public Text time;
    public Text recordatorio;

    private void OnMouseDown()
    {
        if (time.text != "0" && (panelbalde.activeSelf==true) && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            panelbalde.SetActive(false);
            recordatorio.text = "Rápido, corre a la fogata y apágala!";
            panelwater.SetActive(true);
        }
        else if (time.text != "0" && (panelbalde.activeSelf == false) && (panelwater.activeSelf == false) && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            recordatorio.text = "Busca algo en que llevar agua!";
        }
        
       
    }
}