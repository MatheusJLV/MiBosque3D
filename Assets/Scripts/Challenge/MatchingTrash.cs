using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;

public class MatchingTrash : MonoBehaviour
{
    
    public GameObject lastSelectedObject;
    public string[] trash;
    public static int recogidos;
    public GameObject paneldes;
    public GameObject panelitem;
    public Text n;
    public Text correcto;



    private void OnMouseDown()
    {
        if(!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas)){
            MatchingItems();
            print(lastSelectedObject.GetComponent<LastSO>().nameObject);
        }
    }

    public void MatchingItems()
    {
        foreach (string t in trash)
        {
            if (lastSelectedObject.GetComponent<LastSO>().nameObject != t)
            {
                paneldes.SetActive(true);
                correcto.text = "INCORRECTO";
                print("Not matching");

            }
            if (lastSelectedObject.GetComponent<LastSO>().nameObject == t)
            {
                print("Matching");
                StartCoroutine(Esperar());
                break;

            }
        }
            
                
                


    }

    IEnumerator Esperar()
    {
        correcto.text = "CORRECTO";
        recogidos += 1;
        Debug.Log(recogidos);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = false;
        n.text = recogidos.ToString();
        paneldes.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.8f);
        paneldes.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = true;
        lastSelectedObject.GetComponent<LastSO>().nameObject = "";
        panelitem.SetActive(false);
        



    }

}
