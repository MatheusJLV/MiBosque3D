using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickTrash : MonoBehaviour
{
    private bool activate = true;
    public int id;
    public GameObject feedback;
    public Text msj;

    private void OnMouseDown()
    {
        if(activate && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
            StartCoroutine(Picking());
            activate=false;
    }


    IEnumerator Picking()
    {
        msj.text = "Has recogido una basura. Revisa tu mochila ";
        feedback.SetActive(true);
        GameManager.instance.mochila.TestAddAcc(id);
        yield return new WaitForSeconds(1.5f);
        feedback.SetActive(false);
        this.gameObject.SetActive(false);
    }


    
}
