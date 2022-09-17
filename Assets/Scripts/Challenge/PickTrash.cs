using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickTrash : MonoBehaviour
{
    private bool activate = true;
    public int id;
    public GameObject feedback;
    public Text msj;

    public GameObject jugador;

    float timeElapsed =0;
    float lerpDuration = 1f;
    Vector3 startValue;
    Vector3 endValue;
    bool movimiento = false;

    private GameObject puntero;

    private void Start()
    {
        puntero = GameObject.Find("Crosshair/Image");
    }
    private void OnMouseEnter()
    {
        puntero.GetComponent<Puntero>().agarrar();
    }
    private void OnMouseExit()
    {
        puntero.GetComponent<Puntero>().mira();
    }


    void Update()
    {
        if(movimiento)
        {
            if (timeElapsed < lerpDuration)
            {
                this.transform.position = Vector3.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
            }
            if (timeElapsed >= lerpDuration)
            {
                movimiento = false;
                StartCoroutine(Picking());
            }
        }
    }

    private void OnMouseDown()
    {
        if(activate && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            startValue = this.transform.position;
            endValue=jugador.transform.position + new Vector3(0,-5,0);
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            movimiento = true;
            activate=false;
        }
    }


    IEnumerator Picking()
    {
        msj.text = "Has recogido una basura. Revisa tu mochila ";
        feedback.SetActive(true);
        GameManager.instance.mochila.TestAddAcc(id);
        yield return new WaitForSeconds(1f);
        feedback.SetActive(false);
        this.gameObject.SetActive(false);
        GameObject.Find("Control Mochila").GetComponent<MochilaCtrl>().Notificar("basura");
    }


    
}
