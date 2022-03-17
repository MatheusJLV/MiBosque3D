using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonDialogo : MonoBehaviour
{

    //public DialogueTrigger dialogueTrigger;

    public Sprite ardilla;
    public Sprite iguana;
    public Sprite pepiche;
    public PistaButton pista;
    public GameObject CanvasPlayerGUI;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        GameObject.Find("Control Lupa").SetActive(false);
#endif
        //dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
            {

                string uno = "\nSe encuentra en la primera estación, cerca de donde realizas el tutorial.";
                string final = "\nSi continúas avanzando, verás algo muy verde.";
                string dos = "\nDebes continuar hasta el final de la estación dos.";
                string combinado = uno + final + dos;
                Dialogue dialogue = new Dialogue();
                dialogue.title = new string[] { "Pista de la ubicación de la Ardilla", "Pista de la ubicación de la Iguana", "Pista de la ubicación de Pepiche" };
                dialogue.sentences = new string[] { uno, final, dos };
                dialogue.sprites = new Sprite[] { ardilla, iguana, pepiche };
                DialogueManager.instance.StartDialogue(dialogue, "", null, 2);
            }
        }
#if UNITY_ANDROID || UNITY_IOS
        if(pista.Pressed){
            if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
            {

                string uno = "\nSe encuentra en la primera estación, cerca de donde realizas el tutorial.";
                string final = "\nSi continúas avanzando, verás algo muy verde.";
                string dos = "\nDebes continuar hasta el final de la estación dos.";
                string combinado = uno + final + dos;
                Dialogue dialogue = new Dialogue();
                dialogue.title = new string[] { "Pista de la ubicación de la Ardilla", "Pista de la ubicación de la Iguana", "Pista de la ubicación de Pepiche" };
                dialogue.sentences = new string[] { uno, final, dos };
                dialogue.sprites = new Sprite[] { ardilla, iguana, pepiche };
                DialogueManager.instance.StartDialogue(dialogue, "", null, 2);
                CanvasPlayerGUI.SetActive(false);
                pista.setPressed();
                if (GameObject.Find("ArdillaCajaTexto") != null)
                {
                    GameObject.Find("ArdillaCajaTexto").SetActive(false);
                }
                if (GameObject.Find("IguanaCajaTexto") != null)
                {
                    GameObject.Find("IguanaCajaTexto").SetActive(false);
                }
                if (GameObject.Find("PepicheCajaTexto") != null)
                {
                    GameObject.Find("PepicheCajaTexto").SetActive(false);
                }
            }
        }
#endif
    }


    public void EnableButtonDialogue()
    {

        this.gameObject.SetActive(true);

    }
}
