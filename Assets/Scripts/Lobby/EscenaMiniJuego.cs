using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class EscenaMiniJuego : MonoBehaviour
{
    public Image img;
    AsyncOperation operation;
    public Slider slider;
    public Text progressText;
    public static int idCabin;

    private void OnTriggerEnter(Collider other)
    {
        GameObject player = GameObject.Find("FPSController");
        FirstPersonController fps = player.GetComponent<FirstPersonController>();
        fps.canRotate = false;
        fps.canMove = false;
        fps.m_WalkSpeed = 0;
        {
            img.enabled = true;
            SceneManager.LoadScene("Memoria");
        }
    }


    public void cambioEscenaMammals()
    {
        GameObject player = GameObject.Find("FPSController");
        FirstPersonController fps = player.GetComponent<FirstPersonController>();
        fps.canRotate = false;
        fps.canMove = false;
        fps.m_WalkSpeed = 0;
        SceneManager.LoadSceneAsync("Memoria", LoadSceneMode.Additive);
        idCabin = 0;    //CabinMammals
         
       // Pone el EventToTrigger en vacio para que se pueda llamar al evento cuantas veces quiera
        GameObject evento = GameObject.Find("DialogueManager");
        DialogueManager ev = evento.GetComponent<DialogueManager>();
        ev.currentEventToTrigger = "";

        //Desactiva el box Collider para que no de errores si el evento se activa
        GameObject trigger = GameObject.Find("MinigameColliderMamal");
        BoxCollider box = trigger.GetComponent<BoxCollider>();
        box.isTrigger = false;
    }
    public void cambioEscenaBirds()
    {
        GameObject player = GameObject.Find("FPSController");
        FirstPersonController fps = player.GetComponent<FirstPersonController>();
        fps.canRotate = false;
        fps.canMove = false;
        fps.m_WalkSpeed = 0;
        SceneManager.LoadSceneAsync("Memoria", LoadSceneMode.Additive);
        idCabin = 1;    //CabinBirds

        // Pone el EventToTrigger en vacio para que se pueda llamar al evento cuantas veces quiera
        GameObject evento = GameObject.Find("DialogueManager");
        DialogueManager ev = evento.GetComponent<DialogueManager>();
        ev.currentEventToTrigger = "";

        //Desactiva el box Collider para que no de errores si el evento se activa
        GameObject trigger = GameObject.Find("MinigameColliderAves");
        BoxCollider box = trigger.GetComponent<BoxCollider>();
        box.isTrigger = false;
    }

    public void cambioEscenaPlants()
    {
        GameObject player = GameObject.Find("FPSController");
        FirstPersonController fps = player.GetComponent<FirstPersonController>();
        fps.canRotate = false;
        fps.canMove = false;
        fps.m_WalkSpeed = 0;
        SceneManager.LoadSceneAsync("Memoria", LoadSceneMode.Additive);
        idCabin = 2;    //CabinPlants

        // Pone el EventToTrigger en vacio para que se pueda llamar al evento cuantas veces quiera
        GameObject evento = GameObject.Find("DialogueManager");
        DialogueManager ev = evento.GetComponent<DialogueManager>();
        ev.currentEventToTrigger = "";

        //Desactiva el box Collider para que no de errores si el evento se activa
        GameObject trigger = GameObject.Find("MinigameColliderPlants");
        BoxCollider box = trigger.GetComponent<BoxCollider>();
        box.isTrigger = false;
    }
    /*
    public IEnumerator OnFadeComplete()
    {
        AsyncOperation operation;

        if (GameManager.instance.scene == 0)
        {
            GameManager.instance.scene = 1;
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / .9f);
                slider.value = progress;
                progressText.text = progress * 100f + "%";

                yield return null;
            }
        }
        else
        {
            GameManager.instance.scene = 0;
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log("ESCENA A MAPA");
        }

    }*/
}
