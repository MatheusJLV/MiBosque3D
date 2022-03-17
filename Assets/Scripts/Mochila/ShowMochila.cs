﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowMochila : MonoBehaviour
{
    public GameObject infoWindow;
    public GameObject mochila;
    public GameObject mochilaIcon;
    public GameObject tablonIcon;
    public GameObject helpIcon;
    public GameObject lupaIcon;
    public GameObject salidaMochila;
    private Collider cameraBlocker;
    public GameObject accesoryPanel;
    public GameObject seedsPanel;
    public GameObject perfilScreen;
    public GameObject infoScreen;

    public static bool IsBackPack = false;
    public static bool isInfo = false;
    private FirstPersonController firstPersonController;
    public Profile profile;

    public GameObject cerrarMochila;
    public GameObject CanvasPlayerGUI;
    public LogrosButton logrosButton;

    private List<PreguntaObject> questions;
    private Dictionary<int, (PreguntaObject, GameObject, string)> questionsDict = new Dictionary<int, (PreguntaObject, GameObject, string)>();

    public GameObject Pregunta;
    public GameObject ContentPregunta;
    public GameObject preguntasScreen;
    public GameObject SeccionPreguntas;
    public GameObject SeccionPreguntaInfo;
    public GameObject PreguntaInfoTitulo;
    public GameObject PreguntaStacion;
    public GameObject PreguntaRespuesta;
    public GameObject ContenedorPreg;

    public static int rotaUnaVez = 0;

    private void Awake()
    {
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        cameraBlocker = GameObject.FindGameObjectWithTag("Blocker").GetComponent<Collider>();

        RestClient.Instance.Get(GetPreguntaObjects);

    }

    private void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE 
        cerrarMochila.SetActive(true);
        mochilaIcon.SetActive(true);
        tablonIcon.SetActive(true);
        helpIcon.SetActive(true);
        lupaIcon.SetActive(true);
#endif
#if UNITY_ANDROID || UNITY_IOS
        if(GameObject.Find("Control Mochila") != null) {
            GameObject.Find("Control Mochila").SetActive(false);
        }
#endif
        infoWindow.SetActive(false);
        mochila.SetActive(false);
        salidaMochila.SetActive(false);
#if UNITY_ANDROID || UNITY_IOS
        mochilaIcon.SetActive(false);
#endif
        Player.instance.playerData.mochilaDesbloqueada = true;
    }

    //public void ShowBackPack()
    public void ShowWindow(GameObject window)
    {
        if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            MenuPausa.instance.Pausar();
            window.SetActive(true);
            if (window.Equals(mochila))
            {
#if UNITY_ANDROID || UNITY_IOS
            CanvasPlayerGUI.SetActive(false);
            GameObject.Find("FPSController").GetComponent<JoystickController>().enabled = false;
#endif
                IsBackPack = true;
                //salidaMochila.SetActive(true);
#if UNITY_ANDROID || UNITY_IOS
            salidaMochila.SetActive(false);
#endif
            }
            else
            {
                isInfo = true;
                infoScreen.SetActive(true);
            }
            //Time.timeScale = 0f;
            cameraBlocker.enabled = false;
        }
    }

    public void OnProfileScreen()
    {
        perfilScreen.SetActive(true);
        profile.UpdateProfile();
        infoScreen.SetActive(false);
    }

    public void OnUndoProfile()
    {
        infoScreen.SetActive(true);
        perfilScreen.SetActive(false);
    }


    public void Continuar()
    {
#if UNITY_ANDROID || UNITY_IOS
        CanvasPlayerGUI.SetActive(true);
        GameObject.Find("FPSController").GetComponent<JoystickController>().enabled = true;
        GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>().handle.anchoredPosition = Vector2.zero;
        GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>().input = Vector2.zero;
#endif
        perfilScreen.SetActive(false);
        infoWindow.SetActive(false); // En caso de cerrar de inmediato sin mostrar primero la mochila
        Time.timeScale = 1f;
        mochila.SetActive(false);
        salidaMochila.SetActive(false);
        MenuPausa.instance.Reanudar();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        IsBackPack = false;
        isInfo = false;
    }

    public void OnAccesoryPanelShow()
    {
        seedsPanel.SetActive(false);
        accesoryPanel.SetActive(true);
        DragNDrop.isAccesory = true;
    }

    public void OnSeedsPanelShow()
    {
        seedsPanel.SetActive(true);
        accesoryPanel.SetActive(false);
        DragNDrop.isAccesory = false;
    }

    void Update()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE
        if (Input.GetKeyUp(KeyCode.M))
        {
            if (IsBackPack || isInfo)
            {
                Continuar();
            }
            else
            {
                ShowWindow(mochila);
            }
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            if (IsBackPack || isInfo)
            {
                Continuar();
            }
            else
            {
                ShowWindow(infoWindow);
            }
        }
#endif
#if UNITY_ANDROID || UNITY_IOS
        if (logrosButton.Pressed)
        {
            logrosButton.setPress();
            CanvasPlayerGUI.SetActive(false);
            if (IsBackPack || isInfo)
            {
                Continuar();
            }
            else
            {
                ShowWindow(infoWindow);
            }
        }
#endif


    }


    void GetPreguntaObjects(PreguntaObjectList objectList)
    {
        int cont = 0;
        //Dictionary<int, bool> preguntasPlayer = profile.player.playerData.getPreguntasDict();
        Dictionary<int, bool> preguntasPlayer = GameManager.instance.playerData.getPreguntasDict();

        foreach (PreguntaObject question in objectList.preguntas)
        {
            GameObject pregunta = Instantiate(Pregunta, new Vector3(0, 0, 0), Quaternion.identity);

            pregunta.transform.parent = ContentPregunta.transform;
            RectTransform rt = pregunta.GetComponent<RectTransform>();

            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
            rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
            rt.localScale = new Vector3(1, 1, 1);
            rt.localPosition = new Vector3(0, cont, 0);
            cont = cont - 40;

            RectTransform rtFondo = pregunta.transform.GetChild(0).GetComponent<RectTransform>();
            rtFondo.localPosition = new Vector3(138, rtFondo.localPosition.y, rtFondo.localPosition.z);

            //if (preguntasPlayer.ContainsKey(question.Id))
            //{
            //    if (preguntasPlayer[question.Id])
            //    {
            //        pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=green>" + question.Text + "</color>";
            //    }
            //    else
            //    {
            //        pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=red>" + question.Text + "</color>";
            //    }
            //}
            //else
            //{
            //    pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "???????????";
            //}

            //pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = question.Text;



            UnityEngine.UI.Button button = pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Button>();
            button.onClick.AddListener(delegate { MostrarInfoPreguntas(question.Id); });

            if (preguntasPlayer.ContainsKey(question.Id))
            {
                if (preguntasPlayer[question.Id])
                {
                    pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=green>" + question.Text + "</color>";
                }
                else
                {
                    pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=red>" + question.Text + "</color>";
                }
                questionsDict.Add(question.Id, (question, pregunta, "free"));
            }
            else
            {
                pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "???????????";
                questionsDict.Add(question.Id, (question, pregunta, "block"));
            }



        }

        RectTransform contectRT = ContentPregunta.GetComponent<RectTransform>();
        Debug.Log(cont * -1 + 20);
        contectRT.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, cont * -1 + 20);

    }

    public void OnPreguntasScreen()
    {
        //-----------COLOCA LA SECCIÓN DE PREGUNTAS CORRECTAMENTE-----------
        if (rotaUnaVez == 0) {
            ContenedorPreg.transform.Rotate(0, 127, 0);
            rotaUnaVez++;
        }
        //------------------------------------------------------------------


        preguntasScreen.SetActive(true);
        infoScreen.SetActive(false);
    }


    public void MostrarInfoPreguntas(int id)
    {

        (PreguntaObject, GameObject, string) tuplaQueestion = questionsDict[id];
        if (tuplaQueestion.Item3 != "block")
        {

            PreguntaObject question = tuplaQueestion.Item1;

            PreguntaInfoTitulo.GetComponent<UnityEngine.UI.Text>().text = question.Text;
            PreguntaRespuesta.GetComponent<UnityEngine.UI.Text>().text = "Respuesta: " + question.Options[question.Answer] + "\n\n" + question.Feedback;
            PreguntaStacion.GetComponent<UnityEngine.UI.Text>().text = "Estaciones: ";


            foreach (int estacion in question.Stations)
            {
                PreguntaStacion.GetComponent<UnityEngine.UI.Text>().text += " " + estacion;

            }
            SeccionPreguntas.SetActive(false);
            SeccionPreguntaInfo.SetActive(true);
        }




    }

    public void CerrarPreguntaInfo()
    {
        SeccionPreguntaInfo.SetActive(false);
        SeccionPreguntas.SetActive(true);
    }


    public void desbloquearPregunta(int id, bool correcta)
    {
        (PreguntaObject, GameObject, string) tuplaQueestion = questionsDict[id];
        PreguntaObject question = tuplaQueestion.Item1;
        GameObject pregunta = tuplaQueestion.Item2;
        if (correcta)
        {
            pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=green>" + question.Text + "</color>";
            questionsDict.Remove(id);
            questionsDict.Add(id, (question, pregunta, "free"));
            GameManager.instance.playerData.addPregunta(id, correcta);
        }
        else if (tuplaQueestion.Item3.Equals("block"))
        {
            pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=red>" + question.Text + "</color>";
            questionsDict.Remove(id);
            questionsDict.Add(id, (question, pregunta, "free"));
            GameManager.instance.playerData.addPregunta(id, correcta);
        }
        else {
            pregunta.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "<color=red>" + question.Text + "</color>";
            questionsDict.Remove(id);
            questionsDict.Add(id, (question, pregunta, "free"));
            GameManager.instance.playerData.addPregunta(id, correcta);
        }


        //profile.player.playerData.addPregunta(id, correcta);
    }

}
