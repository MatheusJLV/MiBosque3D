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
    public GameObject agua;
    public GameObject pendienteGO;


    private void OnMouseDown()
    {
        if (time.text != "0" && (panelbalde.activeSelf==true) && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            agua.SetActive(true);
            panelbalde.SetActive(false);
            recordatorio.text = "Rápido, corre a la fogata y apágala!";
            panelwater.SetActive(true);
            pendienteGO.GetComponent<DialogueTrigger>().dialogue.sentences[0] = "No hay tiempo que perder! Apaga la fogata ahora que tienes el agua!";
        }
        else if (time.text != "0" && (panelbalde.activeSelf == false) && (panelwater.activeSelf == false) && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            recordatorio.text = "Busca algo en que llevar agua!";
        }
        
       
    }
}