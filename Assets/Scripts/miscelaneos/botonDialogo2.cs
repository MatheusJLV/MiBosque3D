using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonDialogo2 : MonoBehaviour
{
    //public DialogueTrigger dialogueTrigger;

    public Sprite rata;
    public Sprite salamandra;
    public Sprite rata2;
    public PistaButton pista;
    public GameObject CanvasPlayerGUI;

    // Start is called before the first frame update
    void Start()
    {
        //dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
            {

                string uno = "\nAl inicio de la cuarta estación se encuentra el primer ratón.";
                string final = "\nLa salamandra se encuentra en un poste de madera, el cual está más adelante.";
                string dos = "\nUno de los ratones se encuentra detrás del árbol en donde se encuentra el plato brillante";
                //string combinado = uno + final + dos;
                Dialogue dialogue = new Dialogue();
                dialogue.title = new string[] { "Encuentra la comida para el gavilán", "Encuentra la comida para el gavilán", "Encuentra la comida para el gavilán" };
                dialogue.sentences = new string[] { uno, final, dos };
                dialogue.sprites = new Sprite[] { rata, salamandra, rata2 };
                DialogueManager.instance.StartDialogue(dialogue, "", null, 2);
            }
        }
#if UNITY_ANDROID || UNITY_IOS
        if(pista.Pressed){
            if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
            {

                string uno = "\nAl inicio de la cuarta estación se encuentra el primer ratón.";
                string final = "\nLa salamandra se encuentra frente al árbol en donde se encunetra el plato brillante.";
                string dos = "\nUno de los ratones se encuentra detrás del árbol en donde se encuentra el plato brillante";
                //string combinado = uno + final + dos;
                Dialogue dialogue = new Dialogue();
                dialogue.title = new string[] { "Encuentra la comida para el gavilán", "Encuentra la comida para el gavilán", "Encuentra la comida para el gavilán" };
                dialogue.sentences = new string[] { uno, final, dos };
                dialogue.sprites = new Sprite[] { rata, salamandra, rata2 };
                DialogueManager.instance.StartDialogue(dialogue, "", null, 2);
                CanvasPlayerGUI.SetActive(false);
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
