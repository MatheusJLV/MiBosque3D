using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class Desafio : MonoBehaviour
{
    //public GameObject desafio;
    public CharacterMisions personaje;
    public GameObject desafioInfo;
    private FirstPersonController firstPersonController;
    private MouseController mouseController;

    public GameObject imageCorrecto;
    [TextArea(3, 10)]
    public string[] texto, titulo;
    public bool disappear;
    public TextMeshProUGUI textDialog, textTitle;
    private int n_dialogues;
    protected bool dialogoCompletado;

    public bool activo;
    public bool dialogOpen;
    public Button cerrar, step;
    private IEnumerator wait;

    public virtual void Start()
    {
        //desafio.SetActive(false);
        n_dialogues = 0;
        dialogoCompletado = false;
        activo = false;
        dialogOpen = false;
        firstPersonController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        mouseController = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>();
    }

    public void IntroductionDialog()
    {
        firstPersonController.enabled = false;
        mouseController.enabled = false;
        //desafio.SetActive(true);
        activo = true;
        desafioInfo.SetActive(false);
        dialogOpen = true;
        Player.instance.isDialogOpened = true;

        textTitle.text = titulo[0];

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        cerrar.onClick.AddListener(delegate { Continuar(); });
        cerrar.enabled = false;
        //step.onClick.AddListener(delegate { ShowingDialog(); });
        step.onClick.AddListener(delegate { ShowingDialog(); });

        if (texto.Length > 0)
        {
            step.enabled = false;
            StartCoroutine(Dialogo(textDialog, texto[n_dialogues]));
            n_dialogues++;
        }
        else
        {
            Debug.Log("No hay dialogos");
        }




    }

    IEnumerator Esperar()
    {

        yield return new WaitForSeconds(12);
        Continuar();
    }

    public void IntroductionDialog(int value)
    {
        firstPersonController.enabled = false;
        mouseController.enabled = false;
        //desafio.SetActive(true);
        if (value == 0)
        {
            personaje.PersonajeFeliz();
        }
        else
        {
            personaje.PersonajeTriste();
        }
        textTitle.text = titulo[value];
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;

        cerrar.onClick.AddListener(delegate { Continuar(); });
        step.onClick.AddListener(delegate { Continuar(); });
        step.enabled = false;

        StartCoroutine(Dialogo(textDialog, texto[value]));
        wait = Esperar();
        StartCoroutine(wait);



    }

    private void ShowingDialog()
    {
        if (n_dialogues < texto.Length)
        {
            if (step.enabled)
            {
                step.enabled = false;
                textTitle.text = titulo[n_dialogues];
                StartCoroutine(Dialogo(textDialog, texto[n_dialogues]));
                n_dialogues++;
            }

        }
        else
        {
            Continuar();
        }
    }

    IEnumerator Dialogo(TextMeshProUGUI dialogoPersonaje, string texto)
    {
        dialogoPersonaje.text = string.Empty;
        foreach (char letter in texto.ToCharArray())
        {
            dialogoPersonaje.text += letter;
            yield return null;
        }
        cerrar.enabled = true;
        //step.enabled = true;
        step.enabled = true;
    }

    public void Continuar()
    {
        Time.timeScale = 1f;
        firstPersonController.enabled = true;
        mouseController.enabled = true;
        //desafio.SetActive(false);
        desafioInfo.SetActive(true);


        personaje.PersonajeRestart();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        imageCorrecto.SetActive(false);
        dialogoCompletado = true;
        dialogOpen = false;
        Player.instance.isDialogOpened = false;

        if (wait != null)
        {
            StopCoroutine(wait);
        }
        else
        {
            Debug.Log("wait is null");
        }


        if (disappear == true)
        {
            DestroyScriptInstance();
        }
        else
        {
            n_dialogues = 0;
        }

    }

    void DestroyScriptInstance()
    {
        desafioInfo.SetActive(false);
        Destroy(this);
    }
}
