using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;
using UnityEngine.UI;

public class SprintTutorial : MonoBehaviour
{
    public GameObject controlesRenderer;
    public GameObject btn;
    public TextMeshProUGUI indicaciones;
    public TextMeshProUGUI btnText;
    private FirstPersonController fpsController;
    private float acum;
    private int timeRunning;
    public bool active;
    public int tiempoCorrer = 5;
    private string msjsalto = "Presiona                        para CORRER: ";
     public Sprite shiftkey;
    
    public Image cont;

    
    private void Start()
    {
        timeRunning = 0;
        active = true;
        acum = 0;
        if (!fpsController)
            fpsController = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        btnText.text = "Shift";
        indicaciones.text = msjsalto;
        cont.sprite = shiftkey;
        cont.enabled=true;

    }

    private void Update()
    {
        if (!MenuPausa.IsPaused && active)
        {
            if (fpsController.m_IsRunning)
            {
                acum += Time.deltaTime;
                timeRunning = (int)acum % 60;
                indicaciones.text = msjsalto + timeRunning.ToString() + "s";
            }
            if (timeRunning >= tiempoCorrer)
            {
                active = false;
                btn.SetActive(false);
                cont.enabled=false;
                HideIndications();
                GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }

    }

    public void ShowIndications()
    {
        controlesRenderer.SetActive(true);
        btn.SetActive(true);
    }

    public void HideIndications()
    {
        controlesRenderer.SetActive(false);
        btn.SetActive(false);
    }
}