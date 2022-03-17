using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Nest : MonoBehaviour
{
    public static bool home = false;
    public GameObject feedback;
    public Text message;
    private bool active=true;

    private void OnMouseDown()
    {
        if(active && Squirrel.caught && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            Debug.Log("is working");
            home = true;
            Squirrel.activate = false;
            StartCoroutine(ShowFeedback());
            active=false;
        }
    }

    IEnumerator ShowFeedback()
    {
        message.text = "Gran trabajo ve al final de la estación";
        feedback.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        feedback.SetActive(false);
    }
}
