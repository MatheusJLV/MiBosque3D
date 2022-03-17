using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class Controles_Controller : MonoBehaviour
{

    private int contador;
    private int maximo;
    public bool active;
    public GameObject controlesRenderer;
    public TextMeshProUGUI btnText;
    public GameObject btn;
    public GameObject btnSaltoText;
    public TextMeshProUGUI indicacionesText;
    private Collider boxCollider;

    private KeyCode[] keys;
    private string[] keynames;
    private string[] direction = new string[] { "ADELANTE", "a la IZQUIERDA", "ATRÁS", "a la DERECHA" };
    private string msj = "Presiona            para moverte ";
    private string msjsalto = "Presiona                        para SALTAR";
    private string msjExito = "Avanza hacia ADELANTE para continuar";

    public Sprite[] keysimage;
    //public GameObject imagecontet;
    public Image cont;
    //public GameObject otre;


    // Start is called before the first frame update
    void Start()
    {
        //imagecontet = GetComponent<SpriteRenderer>();
        //cont = GetComponent<Image>();
        cont.sprite =  keysimage[0];

        controlesRenderer.SetActive(false);
        btn.SetActive(false);
        //imagecontet.SetActive(false);

        contador = 0;
        active = false;
        keys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.Space };
        keynames = new string[] { "W", "A", "S", "D" };
        maximo = keynames.Length;
        boxCollider = GetComponent<BoxCollider>();
        cont.enabled=false;
    }

    private void Update()
    {
        if (!MenuPausa.IsPaused)
        {
            if (contador > maximo && active)
            {
                active = false;
                btnSaltoText.SetActive(false);
                indicacionesText.text = msjExito;
                boxCollider.isTrigger = true;
                cont.enabled=false;
            }
            else
            {
                if (active && Input.GetKeyDown(keys[contador]))
                {

                    contador++;

                    if (contador < maximo)
                    {
                        btnText.text = keynames[contador];
                        indicacionesText.text = msj + direction[contador];
                        cont.sprite = keysimage[contador];

                        
                    }
                    else if (contador == maximo)
                    {
                        cont.enabled=true;
                        btn.SetActive(false);
                        indicacionesText.text = msjsalto;
                        btnSaltoText.SetActive(true);
                        cont.sprite = keysimage[contador];
                    }

                }
            }
        }
    }

    public void activateControlView()
    {
#if UNITY_ANDROID || UNITY_IOS
        boxCollider.enabled = false;
#elif UNITY_EDITOR || UNITY_STANDALONE_WIN
        active = true;
        cont.enabled = true;

        controlesRenderer.SetActive(true);
        btn.SetActive(true);
        btnText.text = keynames[contador];
#endif
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            controlesRenderer.SetActive(false);
            btn.SetActive(false);
            Destroy(this.gameObject);
        }
    }


}
