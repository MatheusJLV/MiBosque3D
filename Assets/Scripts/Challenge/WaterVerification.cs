using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterVerification : MonoBehaviour
{
    public GameObject panelwater;
    public GameObject panelbalde;
    public GameObject panelMsj;
    public GetWater well;
    public Text texto;
    public Image img;
    public GameObject time;
    public static bool fuegoApagado = false;
    public float tiempo = 60;
    private bool active = true;
    public Text contador;
    public ChallengePass5 challengePass5;
    public GameObject[] particulas_de_fuego;
    public GameObject recordatorio;
    public AudioScript clockSound;
    private Collider cameraBlocker;
    public GameObject CanvasJoysticks;
    private void Awake() {
        cameraBlocker = GameObject.FindGameObjectWithTag("Blocker").GetComponent<Collider>();
        
    }

    private void Start()
    {
        clockSound.reproducir();
        time.SetActive(true);
    }

    void Update()
    {
        if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas) && active)
        {
            /* ya no con tiempo
            tiempo -= Time.deltaTime;
            int timeRunning = (int)tiempo % 60;
            contador.text = timeRunning.ToString();
            if (tiempo < 0)
            {
                clockSound.detener();
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
                Destroy(this.gameObject.transform.GetChild(1).gameObject);
                Destroy(this.gameObject.transform.GetChild(2).gameObject);
                panelwater.SetActive(false);
                panelbalde.SetActive(false);
                challengePass5.dialogoDesafioCompleto.SetActive(false);
                challengePass5.dialogoDesafioPendiente.SetActive(false);
                challengePass5.dialogoDesafioFallado.SetActive(true);
                active = false;
                time.SetActive(false);
                recordatorio.SetActive(false);
                cameraBlocker.enabled=true;
                texto.text = "Se te ha acabado el tiempo y alguien más ha llegado a apagar el fuego. Avanza a la siguiente estación";
                img.sprite = Resources.Load<Sprite>("ninapreoc");
                panelMsj.SetActive(true);
                MenuPausa.instance.Pausar();
                GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = false;
                Destroy(well);
            }

        */

            /*tiempo -= Time.deltaTime;
            if (contador.text != "0")
            {
                contador.text = tiempo.ToString("f0");
            }


            if (tiempo <= 0 && c <= 0)
            {
                contador.text = "0";

                StartCoroutine(Esperar());

                c += 1;

            }*/
        }
    }

    private void OnMouseDown()
    {
        if (active && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
#if UNITY_ANDROID || UNITY_IOS
            CanvasJoysticks.SetActive(false);
#endif

            MenuPausa.instance.Pausar();
            GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = false;
            cameraBlocker.enabled=true;

            if (panelwater.activeSelf)
            {
                Debug.Log("Entro con agua");
                contador.text = "0";
                clockSound.detener();
                Destroy(this.gameObject.transform.GetChild(0).gameObject);
                Destroy(this.gameObject.transform.GetChild(1).gameObject);
                Destroy(this.gameObject.transform.GetChild(2).gameObject);
                Destroy(this.gameObject.transform.GetChild(3).gameObject);
                foreach(GameObject obj in particulas_de_fuego)
                {
                    obj.SetActive(false);
                }
                Debug.Log("destruyo particulas y sonido");

                panelwater.SetActive(false);
                panelbalde.SetActive(false);
                time.SetActive(false);
                recordatorio.SetActive(false);
                Debug.Log("Seteo actives");
                texto.text = "Lo lograste! Has apagado el fuego, puedes continuar a la siguiente estación";
                fuegoApagado = true;
                //img.sprite = Resources.Load<Sprite>("ninabien");
                img.sprite = Resources.Load<Sprite>("smoke");
                //panelMsj.SetActive(true);
                Continuar();
                active = false;
                Destroy(well);
            }


            else
            {
                //img.sprite = Resources.Load<Sprite>("ninapreoc");
                img.sprite = Resources.Load<Sprite>("fire");
                texto.text = "Aún no tienes agua para apagar el fuego. Busca agua por los alrededores. Traela en un recipiente!";
                panelMsj.SetActive(true);
            }

        }
    }

    public void Continuar()
    {
#if UNITY_ANDROID || UNITY_IOS
        CanvasJoysticks.SetActive(true);
#endif

        panelMsj.SetActive(false);
        MenuPausa.instance.Reanudar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        cameraBlocker.enabled=false;
    }
}