using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Pick : MonoBehaviour
{
    public bool activate = false;
    public PlateFood plateFood;
    public int id;
    public GameObject feedback;
    public Text message;
    public HamsterCage cage;

    private void OnMouseDown()
    {
        if (activate && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            StartCoroutine(Esperar());
            activate=false;
            if (id == 2)
                cage.ActivateSal();
            else if (id == 1)
                cage.ActivateRat();
        }
    }

    IEnumerator Esperar()
    {
        plateFood.recogidos += 1;
        message.text = "Has atrapado un " + name + " en tu mochila";
        feedback.SetActive(true);
        GameManager.instance.mochila.TestAddF(id);
        yield return new WaitForSeconds(1.5f);
        feedback.SetActive(false);
        this.gameObject.SetActive(false);

    }


}
