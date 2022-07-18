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

    private MouseController mouseController;
    private Collider cameraBlocker;
    private void Start()
    {
        mouseController = ConstantObjects.instance.mouseController;
        cameraBlocker = ConstantObjects.instance.cameraBlocker;
    }

    void Update()
    {
        if (movimiento)
        {
            if (timeElapsed < lerpDuration)
            {
                mouseController.enabled = false;
                cameraBlocker.enabled = true;
                MenuPausa.instance.Pausar();
                this.transform.position = Vector3.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            if (timeElapsed >= lerpDuration)
            {
                movimiento = false;
                this.transform.SetParent(holding.transform);
                mouseController.enabled = true;
                cameraBlocker.enabled = false;
                MenuPausa.instance.Reanudar();
                //StartCoroutine(Picking());
            }
        }
    }

    private void OnMouseDown()
    {
        if (time.text != "0" && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            startValue = this.transform.position;
            endValue = jugador.transform.position - 0.25f*(jugador.transform.position-this.transform.position) + new Vector3(0,-2.5f,0);
            movimiento = true;
            panelbalde.SetActive(true);
            recordatorio.text = "Busca agua, ¡escucha a tu alrededor!";
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            //Destroy(objeto);
        }
        panelbalde.SetActive(true);
    }
}
