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

    public GameObject jugador;
    public GameObject holding;

    float timeElapsed = 0;
    float lerpDuration = 1f;
    Vector3 startValue;
    Vector3 endValue;
    bool movimiento = false;

    void Update()
    {
        if (movimiento)
        {
            if (timeElapsed < lerpDuration)
            {
                this.transform.position = Vector3.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            if (timeElapsed >= lerpDuration)
            {
                movimiento = false;
                this.transform.SetParent(holding.transform);
                //StartCoroutine(Picking());
            }
        }
    }

    private void OnMouseDown()
    {
        if (time.text != "0" && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            startValue = this.transform.position;
            endValue = jugador.transform.position - 0.25f*(jugador.transform.position-this.transform.position) ;
            movimiento = true;
            panelbalde.SetActive(true);
            recordatorio.text = "Busca agua, ¡escucha a tu alrededor!";
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            //Destroy(objeto);
        }
        panelbalde.SetActive(true);
    }
}
