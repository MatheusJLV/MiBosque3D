using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.Networking;
using TMPro;
using System.IO;
using UnityEngine.Events;
using System.Threading;

public class WallTrigger_2 : MonoBehaviour
{

    public Animator canvasAnim;
    public GameObject canvasPreguntasImagenes;
    public GameObject canvasFeedback;
    public GameObject pacoCorrecto, pacoIncorrecto;
    public GameObject controlPanel;
    public Text cantidadEstrellas, pregunta, desafio, preguntaImagen;
    public TextMeshProUGUI Title;
    public Text titlePequeño, dialogo;
    private string texto, textoTitle;
    public Button m_opcionAImagenes, m_opcionBImagenes, m_opcionCImagenes, m_opcionDImagenes;
    public Image m_ImagenA, m_ImagenB, m_ImagenC, m_ImagenD, f_Imagen;
    private int value_A, value_B, value_C, value_D;
    private string opt1, opt2, opt3, opt4;
    private string respuesta;
    private string feedback;
    private string url_preguntas = SystemVariables.url_puerto + "/api/bpv/question";
    private string url_api = SystemVariables.url_puerto + "/resources/bpv/images/species/";
    private string url_info = SystemVariables.url_puerto + "/api/bpv/specie/";
    private List<PreguntaObject> questions;
    static List<int> usadas;
    private PreguntaObject q;
    private SpecieObject tmp = null;
    public int n_estacion;
    public RawImage imagen;
    public string nombreEvento;
    public AudioClip correct;
    public AudioClip incorrect;
    public GameObject joystick;

    public ShowMochila mochila;

    public GameObject actionLogger;


    void Start()
    {
        usadas = new List<int>();
        actionLogger = GameObject.Find("ActionLogger");
    }

    public void DestroyScriptInstance()
    {
        // Removes this script instance from the game object
        //Destroy(this.gameObject);
    }

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("BEGIN COLISION");
#if UNITY_ANDROID || UNITY_IOS
        joystick.SetActive(false);
#endif
        if (obj.gameObject.tag == "Player")
        {
            //StartCoroutine(RestClient.Instance.Get(url_preguntas, GetPreguntaObjects));
            RestClient.Instance.Get(GetPreguntaObjects);
            StartCoroutine(Preguntas());
            controlPanel.GetComponent<Animator>().SetBool("hide", true);
        }
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("END COLISION");
    }

    IEnumerator Preguntas()
    {
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("BEGIN ENIM PREGUNTAS");
        MenuPausa.instance.Pausar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = false;
        //Panel.SetActive(false);
        //mira.SetActive(false);
        Time.timeScale = 1f;

        m_opcionAImagenes.onClick.AddListener(delegate { Wrapper(value_A,opt1); });
        m_opcionBImagenes.onClick.AddListener(delegate { Wrapper(value_B, opt2); });
        m_opcionCImagenes.onClick.AddListener(delegate { Wrapper(value_C, opt3); });
        m_opcionDImagenes.onClick.AddListener(delegate { Wrapper(value_D, opt4); });


        //texto = "Hola, veamos si has prestado atencion, a ver si puedes contestar la siguiente pregunta";
        //Title.enabled = true;
        //titlePequeño.enabled = false;
        //dialogo.enabled = false;
        //canvasAnim.SetBool("IsOpen", true);
        //textoTitle = "Desafío \nN°" + (n_estacion - 1) + "\nContesta la siguiente pregunta";
        //canvasDialogo.SetActive(true);
        //StartCoroutine(Dialogo(Title, textoTitle));
        yield return new WaitForSeconds(0.2f);
        //Title.enabled = false;
        //titlePequeño.enabled = true;
        //dialogo.enabled = true;
        //canvasAnim.SetBool("IsOpen", false);
        //fondoCanvasDialogo.SetActive(false);

        canvasPreguntasImagenes.SetActive(true);
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("END ENUM PREG");
    }

    public void Continuar()
    {
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("BEGIN CONTINUAR");
#if UNITY_ANDROID || UNITY_IOS
        joystick.SetActive(true);
#endif
        Time.timeScale = 1f;
        //fondoCanvasDialogo.SetActive(false);
        MenuPausa.instance.Reanudar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = true;
        //Panel.SetActive(true);
        //mira.SetActive(true);
        Title.enabled = true;
        DestroyScriptInstance();
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("END CONTINUAR");
    }

    public void Wrapper(int i,string opt)
    {
        if (i == 1)
        {
            RespuestaCorrecta(opt);
            AudioSourceSFX.instance.PlaySound(correct);
        }
        else
        {
            RespuestaIncorrecta(opt);
            AudioSourceSFX.instance.PlaySound(incorrect);
        }
    }

    private void RespuestaIncorrecta(string opt)
    {
        //aqui
        actionLogger.GetComponent<ActionLogger>().actionLogger.agregarAccion(pregunta.text, "incorrecta");
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("BEGIN RESPUESTA INC");
        canvasPreguntasImagenes.SetActive(false);

        canvasFeedback.transform.Find("Titulo correcto").gameObject.SetActive(false);
        canvasFeedback.transform.Find("Subtitulo correcto").gameObject.SetActive(false);
        canvasFeedback.transform.Find("Titulo incorrecto").gameObject.SetActive(true);
        pacoCorrecto.SetActive(false);
        pacoIncorrecto.SetActive(true);
        canvasFeedback.transform.Find("Feedback").gameObject.GetComponent<Text>().text = feedback;
        canvasFeedback.transform.Find("check").gameObject.SetActive(false);
        canvasFeedback.transform.Find("cross").gameObject.SetActive(true);
        f_Imagen.sprite = Resources.Load<Sprite>(q.image);
        canvasFeedback.transform.Find("Button").gameObject.GetComponent<Button>().onClick.AddListener(CloseFeedbackCanvas);
        canvasFeedback.transform.localPosition.Set(33.28f, -0.8f, 0);
        Debug.Log("marca");
        canvasFeedback.SetActive(true);

        //fondoCanvasDialogo.SetActive(true);
        //personaje.PersonajeTriste();
        //texto = "¡Vaya! Esta vez no has acertado. La respuesta correcta es " + respuesta + ".\n" + feedback;
        //Dialogue dialogue = new Dialogue();
        //dialogue.sentences = new string[] { texto };
        //dialogue.title = new string[dialogue.sentences.Length];
        //dialogue.sprites = new Sprite[dialogue.sentences.Length];
        //DialogueManager.instance.StartDialogue(dialogue, nombreEvento, this.gameObject, 0, false, true);
        //StartCoroutine(Dialogo(fondoCanvasDialogo, dialogoPersonaje, texto));
        //yield return new WaitForSeconds(13.0f);
        //Continuar();
        mochila.desbloquearPregunta(q.ChallengeID, false);
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("END RESP INC");
    }

    private void CloseFeedbackCanvas()
    {
        canvasFeedback.GetComponent<Animator>().SetBool("show", true);
        MenuPausa.instance.Reanudar();
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = true;
        EventManager.eventManager.TriggerEvent(nombreEvento);
        EventManager.StopListening(nombreEvento);
        controlPanel.GetComponent<Animator>().SetBool("hide", false);
    }

    private void RespuestaCorrecta(string opt)
    {
        Debug.Log("mandar a server :" + q.codename +"-" + q.image + "-" + "Bosque-Estación " + n_estacion + "-"+ opt + "-" + q.question);
        
        if (!GameManager.OfflineMode)
        {
            Peticiones.instance.registerPregunta(Player.instance.playerData, System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), opt, "Bosque-Estación " + n_estacion, ""+q.codename);
        }
            Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("BEGIN RESP CORRECTA");
        canvasPreguntasImagenes.SetActive(false);
        actionLogger.GetComponent<ActionLogger>().actionLogger.agregarAccion(pregunta.text, "correcta");

        canvasFeedback.transform.Find("Titulo correcto").gameObject.SetActive(true);
        canvasFeedback.transform.Find("Subtitulo correcto").gameObject.SetActive(true);
        canvasFeedback.transform.Find("Titulo incorrecto").gameObject.SetActive(false);
        pacoCorrecto.SetActive(true);
        pacoIncorrecto.SetActive(false);
        canvasFeedback.transform.Find("Feedback").gameObject.GetComponent<Text>().text = feedback;
        canvasFeedback.transform.Find("check").gameObject.SetActive(true);
        canvasFeedback.transform.Find("cross").gameObject.SetActive(false);
        f_Imagen.sprite = Resources.Load<Sprite>(q.image);
        canvasFeedback.transform.Find("Button").gameObject.GetComponent<Button>().onClick.AddListener(CloseFeedbackCanvas);
        canvasFeedback.transform.localPosition.Set(33.28f, -0.8f, 0);
        Debug.Log("marca");
        canvasFeedback.SetActive(true);

        //fondoCanvasDialogo.SetActive(true);
        //texto = "¡Felicidades! Respuesta correcta.\n" + feedback;
        //texto = "Felicidades tu respuesta: " + respuesta + " es correcta.\n" + feedback;
        //StartCoroutine(Dialogo(fondoCanvasDialogo, dialogoPersonaje, texto));
        //Dialogue dialogue = new Dialogue();
        //dialogue.sentences = new string[] { texto };
        //dialogue.title = new string[dialogue.sentences.Length];
        //dialogue.sprites = new Sprite[dialogue.sentences.Length];
        //        dialogue.title="";
        //DialogueManager.instance.StartDialogue(dialogue, nombreEvento, this.gameObject, 1, false, true);
        int x = 0;
        int y = 0;
        int.TryParse(cantidadEstrellas.text, out x);
        int.TryParse(desafio.text, out y);
        x += 5;
        y += 1;
        cantidadEstrellas.text = x.ToString();
        desafio.text = y.ToString();
        Player.instance.PreguntasCorrectas();
        //yield return new WaitForSeconds(13.0f);
        //Continuar();
        mochila.desbloquearPregunta(q.ChallengeID, true);

        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("END RESP CORRECT");
    }

    IEnumerator Dialogo(TextMeshProUGUI dialogoPersonaje, string texto)
    {
        int longitud = texto.Length;
        int contador = 0;
        dialogoPersonaje.text = string.Empty;
        while (contador < longitud)
        {
            dialogoPersonaje.text = dialogoPersonaje.text + texto[contador];
            contador += 1;
            yield return null;
        }
    }

    void GetPreguntaObjects(PreguntaObjectList objectList)
    {
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("BEGIN GET PREGUNTAS OBJECT");
        Debug.Log("preguntas cargadas");
        Debug.Log(objectList.preguntas.Count);
        questions = new List<PreguntaObject>();
        foreach (PreguntaObject archivoraiz in objectList.preguntas)
        {
            List<int> estacionesDePreg = new List<int>();
            foreach (GameLevelsChallenges gl in archivoraiz.gameLevelsChallenges)
            {
                estacionesDePreg.Add(gl.GameLevelId-1);
            }
            //if (IsInEstacion(archivoraiz.Stations))
            if (IsInEstacion(estacionesDePreg))
            {
                if (questions == null)
                {
                    Debug.Log("es null");
                    questions.Add(archivoraiz);
                }
                questions.Add(archivoraiz);
            }

        }


        bool repeat = true;
        int cont = 0;
        while (repeat)
        {
            //Debug.Log("COUNT:" + questions.Count);
            int rdn = Random.Range(0, questions.Count);
            Debug.Log("question");
            Debug.Log(questions.Count);
            Debug.Log(rdn);
            /*for(int i = 0; i < questions.Count; i++)
            {
                PreguntaObject pqu = questions[i];
                print(pqu.Feedback);
            }*/
            //Debug.Log(questions.Count);
            /*foreach (string t in usadas)
            {
                Debug.Log(t);
            }*/

            q = questions[rdn];
            Debug.Log("la pregunta es "+q.ToString());
            Debug.Log(q.question);
            Debug.Log(q.feedback);
            //Debug.Log(q.question);
            if (!usadas.Contains(q.ChallengeID) || cont==questions.Count)
            {
                if (cont!=questions.Count)
                {
                    usadas.Add(q.ChallengeID);
                }

                LoadImage(q.image);
                pregunta.text = q.question;

                List<string> galeriaImagenes = new List<string>();
                foreach (Option opt in q.options)
                {
                    galeriaImagenes.Add(opt.image);
                }


                //Debug.Log(q.Gallery);
                Debug.Log(galeriaImagenes);
                preguntaImagen.text = q.question;
                /*m_opcionAImagenes.GetComponentInChildren<Text>().text = "A. " + q.options[0];
                m_opcionBImagenes.GetComponentInChildren<Text>().text = "B. " + q.Options[1];
                m_opcionCImagenes.GetComponentInChildren<Text>().text = "C. " + q.Options[2];
                m_opcionDImagenes.GetComponentInChildren<Text>().text = "D. " + q.Options[3];*/
                m_opcionAImagenes.GetComponentInChildren<Text>().text = "A. " + q.options[0].text;
                m_opcionBImagenes.GetComponentInChildren<Text>().text = "B. " + q.options[1].text;
                m_opcionCImagenes.GetComponentInChildren<Text>().text = "C. " + q.options[2].text;
                m_opcionDImagenes.GetComponentInChildren<Text>().text = "D. " + q.options[3].text;
                opt1 = q.options[0].text;
                opt2 = q.options[1].text;
                opt3 = q.options[2].text;
                opt4 = q.options[3].text;
                //aqui
                //if (q.Gallery.Count == 4)
                if (galeriaImagenes.Count == 4)
                {
                    /*m_ImagenA.sprite = Resources.Load<Sprite>("Questions/Images/" + q.Gallery[0]);
                    m_ImagenB.sprite = Resources.Load<Sprite>("Questions/Images/" + q.Gallery[1]);
                    m_ImagenC.sprite = Resources.Load<Sprite>("Questions/Images/" + q.Gallery[2]);
                    m_ImagenD.sprite = Resources.Load<Sprite>("Questions/Images/" + q.Gallery[3]);*/
                    m_ImagenA.sprite = Resources.Load<Sprite>("Questions/Images/" + galeriaImagenes[0]);
                    m_ImagenB.sprite = Resources.Load<Sprite>("Questions/Images/" + galeriaImagenes[1]);
                    m_ImagenC.sprite = Resources.Load<Sprite>("Questions/Images/" + galeriaImagenes[2]);
                    m_ImagenD.sprite = Resources.Load<Sprite>("Questions/Images/" + galeriaImagenes[3]);
                }
                else
                {
                    m_ImagenA.sprite = Resources.Load<Sprite>("Questions/Images/default");
                    m_ImagenB.sprite = Resources.Load<Sprite>("Questions/Images/default");
                    m_ImagenC.sprite = Resources.Load<Sprite>("Questions/Images/default");
                    m_ImagenD.sprite = Resources.Load<Sprite>("Questions/Images/default");
                }

                //m_opcionA.GetComponentInChildren<Text>().text = "A. " + q.Options[0];
                //m_opcionB.GetComponentInChildren<Text>().text = "B. " + q.Options[1];
                //m_opcionC.GetComponentInChildren<Text>().text = "C. " + q.Options[2];
                //m_opcionD.GetComponentInChildren<Text>().text = "D. " + q.Options[3];
                value_A = 0;
                value_B = 0;
                value_C = 0;
                value_D = 0;
                //for (int i = 0; i < 4; i++)
                {
                    if (q.options[0].correctOption)
                    {
                        value_A = 1;
                        respuesta = q.options[0].text;
                    }
                    else if (q.options[1].correctOption)
                    {
                        value_B = 1;
                        respuesta = q.options[1].text;
                    }
                    else if (q.options[2].correctOption)
                    {
                        value_C = 1;
                        respuesta = q.options[2].text;
                    }
                    else
                    {
                        value_D = 1;
                        respuesta = q.options[3].text;
                    }
                }

                //respuesta = q.Options[q.Answer];
                repeat = false;
                feedback = q.feedback.feedback;
            }
            else
            {
                repeat = true;
            }
            cont = cont + 1;
        }
        Debug.Log("WALL TRIGGER 2 SCRIPT");
        Debug.Log("END GET PREGUNTAS OBJECT");
    }

    bool IsInEstacion(List<int> estaciones)
    {
        foreach (int sp in estaciones)
        {
            if (sp == n_estacion)
            {
                return true;
            }
        }
        return false;
    }


    public void LoadImage(string address)
    {
        imagen.texture = Resources.Load<Texture2D>(address);
    }
}