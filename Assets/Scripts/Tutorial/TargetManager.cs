using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class TargetManager: MonoBehaviour
{
    
    int numTargetRed;
    int numTargetGreen;

    int currentTarget;

    public string[] message;
    public Text text;
    int index;

    public FirstPersonController player;

    public GameObject joystick;


    public GameObject button;
    
    public GameObject sceneButton;

    public GameObject panel;    

    public GameObject keyboardImage;
    public GameObject keyboardRun;
    public GameObject keyboardJump;

    public NPCController npc;

    public GameObject RedTargets;

    public GameObject GreenTargets;

    bool canNext = true;

    bool islooked;

    bool isDone;

   
    void Awake()
    {

        button.SetActive(false);

    }
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(texting());
        RedTargets.SetActive(false);
        GreenTargets.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        ImageShow();
        sendBoolNPC();
        pauseTexting();
        activeTexting();
        activePlayerMovement();
        tasks();
        finishedTutorial();
        activeButton();
        
    }

    void activeButton()
    {
        if(text.text == message[index] && index != 12)
        {
            button.SetActive(true);
        }
    }   

    IEnumerator texting()
    {
        // leemos cada letra del mensaje para su visibilidad con una espera de 0.02 segundos
        foreach(char letter in message[index].ToCharArray())
        {
                text.text += letter;
                yield return new WaitForSeconds(0.02f);
        }

        if(index == 3)
        {
            // cuando el index de los mensajes sea 3 aparecen las esferas rojas
            RedTargets.SetActive(true);
            // obtenemos el numero de esferas
            numTargetRed = GameObject.FindGameObjectsWithTag("TargetRed").Length;
            // colocamos el numero de esferas en el panel
            text.text += "\nson "+numTargetRed;

        }

        if(index == 6)
        {
            // cuando el index de los mensajes sea 6 aparecen las esferas verdes
            GreenTargets.SetActive(true);
            // obtenemos el numero de esferas
            numTargetGreen = GameObject.FindGameObjectsWithTag("TargetGreen").Length;
            // colocamos el numero de esferas en el panel
            text.text += "\nson "+numTargetGreen;

        }
                
    }
        
    // set the next message in the screen
    public void nextMessage()
    {
       // ocultamos el boton de siguiente
       button.SetActive(false);

       if(canNext)
       {
            // activamos el panel de texto
            panel.SetActive(true);
            //  validamos si el index sigue siendo menor que el numero de mensajes
            if(index < message.Length - 1)
            {
                index++;
                text.text = "";
                StartCoroutine(texting());
            }            
            
        }else
        {
            panel.SetActive(false);
            text.text = "";
        }       
       
    }

   
    void pauseTexting()
    {
        // si los index son los indicados entramos al if
        if(index == 3 || index == 6) 
        {
            // si el texto en pantalla es igual al mensaje pausamos el texto
            if(text.text == message[index]){

                canNext = false;
            }
            
        }

        if(index == 9 )
        {
            canNext = false;
        }
       
    }

    void activeTexting()
    {
        if(Vector3.Distance(player.transform.position, npc.transform.position) < 2.5)
        {
            
            if(text.text == "")
            {
                canNext = true;
                //button.SetActive(true);
                //panel.SetActive(true);
                //text.text = "Continuemos";
                nextMessage();
            } 
            
                        
        }
    }
    

    void activePlayerMovement()
    {
        if(panel.activeSelf == false)
        {            

#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<FirstPersonController>().enabled = true;
            
#elif UNITY_ANDROID || UNITY_IOS
            joystick.SetActive(true);

#endif            
        }

        if(panel.activeSelf == true)
        {

#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            player.GetComponent<FirstPersonController>().enabled = false;

#elif UNITY_ANDROID || UNITY_IOS
            joystick.SetActive(false);
            
#endif
            
            
        }
    }

     void ImageShow()
    {
        if(index == 1)
        {
            keyboardImage.gameObject.SetActive(true);
        }

         if(index == 3)
        {
            keyboardImage.gameObject.SetActive(false);
        }
        if(index == 5)
        {
            keyboardRun.gameObject.SetActive(true);
        }

         if(index == 6)
        {
            keyboardRun.gameObject.SetActive(false);
        }
        if(index == 9)
        {
            keyboardJump.gameObject.SetActive(true);
        }

         if(index == 10)
        {
            keyboardJump.gameObject.SetActive(false);
        }
        
    }

    //set boolean to the npc in the scene using method
    void sendBoolNPC()
    {
        if(index == 3)
        {
            npc.stateWalking();            
        }

        if(index == 6)
        {
            npc.stateRunning();
        }

        if(index == 9)
        {
            npc.stateJumping();
        }

        if(index == 10)
        {
            npc.stateIdle();
        }
    }


    void tasks()
    {
        numTargetRed = GameObject.FindGameObjectsWithTag("TargetRed").Length;

        numTargetGreen = GameObject.FindGameObjectsWithTag("TargetGreen").Length;

       
        if(index == 12)
        {
            isDone = true;
        }
        
    }

    void finishedTutorial()
    {
        if(isDone)
        {
            player.GetComponent<FirstPersonController>().enabled = false;
            sceneButton.SetActive(true);
        }
    }

   
}
