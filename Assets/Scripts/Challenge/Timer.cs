using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text contador;
    public GameObject game, timer;
    public Text texto;
    public Image img;
    public  float tiempo = 30;
    private bool active=true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!MenuPausa.IsPaused && active)
        {
            tiempo-=Time.deltaTime;
            int timeRunning = (int) tiempo % 60;
            contador.text = timeRunning.ToString();

            if(tiempo<0){
                active=false;
            }
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

    IEnumerator Esperar()
    {
        texto.text = "Se te ha acabado el tiempo y alguien mas ha llegado a apagar el fuego. Avanza a la siguiente estacion";
        img.sprite = Resources.Load<Sprite>("ninapreoc");
        game.SetActive(true);
        MenuPausa.instance.Pausar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = false;

        yield return new WaitForSeconds(5);
        game.SetActive(false);
        timer.SetActive(false);
        MenuPausa.instance.Reanudar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

}
