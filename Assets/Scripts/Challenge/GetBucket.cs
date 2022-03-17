using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GetBucket : MonoBehaviour
{
    public GameObject panelbalde;
    public Text time;
    public Text recordatorio;
    public GameObject objeto;

    private void OnMouseDown()
    {
        if (time.text != "0" && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            panelbalde.SetActive(true);
            recordatorio.text = "Busca agua, ¡escucha a tu alrededor!";
            Destroy(objeto);
        }
        panelbalde.SetActive(true);
    }
}
