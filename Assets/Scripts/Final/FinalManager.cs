using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FinalManager : MonoBehaviour
{
    public GameObject camera;
    public GameObject polo;
    public GameObject NPCs;
    public GameObject ballons;
    public GameObject confetti1;
    public GameObject confetti2;
    public AudioSource audioClap;
    public Canvas canvas;
    public Transform target;
    public int currentSpeed = 3;
    public GameObject miniCertificado;

    public Text playerName;
    public PlayerData playerData;

    public GameObject diploma;
    bool onDiplome = true;
    int segundos = 0;

    
    GameObject background;
    float ending = 0.0f;

    public GameObject credits;
    
    
    // Start is called before the first frame update
    void Start()
    {
        loadData();
        background = canvas.transform.GetChild(0).gameObject;
        diploma = canvas.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > 2 )
        {
            cameraAutoMove();
            statePolo();
        }

        if(onDiplome)
        {
            activeDiplome();
        }

        if(segundos == 9)
        {
            onDiplome = false;
            transitionToCredits();
        }
             
    }

    void cameraAutoMove()
    {
        //genera el vector entre la posicion de la camera y la posicion objetivo
        Vector3 nextPos = Vector3.MoveTowards(camera.transform.position, target.position, currentSpeed*Time.deltaTime);
        // mueve la camera
        camera.GetComponent<Rigidbody>().MovePosition(nextPos);
    }

    void statePolo()
    {
        //cuando el audio de aplausos se detiene entra al if
        if(!audioClap.GetComponent<AudioSource>().isPlaying)
        {
            //cambia la animacion de polo a descanso
            polo.GetComponent<Animator>().SetInteger("state",1);
        }
    }

    void activeDiplome()
    {
        // evalua si la camara esta en la posicion requerida para activar el dilpoma
        if(camera.transform.position.z <= target.position.z)
        {
            //desactivamos el mini cetificado
            miniCertificado.SetActive(false);

            // activamos el diploma
            diploma.SetActive(true);
            
                        
            // aumento de la scale con el paso del tiempo
             RectTransform rt = diploma.GetComponent<RectTransform>();
             rt.localScale = Vector3.Lerp (rt.localScale, new Vector3(1,1,1), 1.5f * Time.deltaTime);

             ending += Time.deltaTime;
             segundos = (int)ending % 60;            
        }        

    }

    void transitionToCredits()
    {
        //silenciamos la musica
        audioClap.GetComponent<AudioSource>().Stop();
        
        Color colorDiplome = diploma.GetComponent<Image>().color;
        colorDiplome.a = Mathf.Lerp(colorDiplome.a, 0.0f, 2 * Time.deltaTime);
        diploma.GetComponent<Image>().color = colorDiplome;

        if(colorDiplome.a < 0.5f)
        {
            diploma.transform.GetChild(0).gameObject.SetActive(false);
        }

        background.SetActive(true);
        Color colorBackground = background.GetComponent<Image>().color;
        colorBackground.a = Mathf.Lerp(colorBackground.a, 1.0f, 2 * Time.deltaTime);

        background.GetComponent<Image>().color = colorBackground;

        if(colorBackground.a > 0.99)
        {
            offElements();
            credits.SetActive(true);
            playCredits();
        }
        
    }

    void playCredits()
    {
        credits.GetComponent<Animator>().Play("Base Layer.Credits",0,0);
    }

    void offElements()
    {
        NPCs.SetActive(false);
        ballons.SetActive(false);
        confetti1.SetActive(false);
        confetti2.SetActive(false);
        polo.SetActive(false);
    }


    void loadData()
    {
        playerData = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().playerData;
        playerName.text = playerData.nombre;
    }

}
