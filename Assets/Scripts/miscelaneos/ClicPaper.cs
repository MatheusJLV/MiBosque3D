using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClicPaper : MonoBehaviour
{
    public bool active;
    public static int clickeados;
    public GameObject panel;
    public Text n;
    private bool done = false;
    public GameObject objFinDesafio;

    private void Start()
    {
        ClicPaper.clickeados = 0;
        active = false;
    }

    private void OnMouseDown()
    {
        if (active && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            Debug.Log("Clickeo un papel");
            StartCoroutine(ActualizarClick());
        }
    }

    IEnumerator ActualizarClick()
    {
        if (!done && ClicPaper.clickeados < 4)
        {
            ClicPaper.clickeados += 1;
            n.text = clickeados.ToString();
            panel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1f;
            done = true;
            active=false;
            yield return new WaitForSeconds(0.8f);
            panel.SetActive(false);
            
            if (ClicPaper.clickeados == 4)
            {
                objFinDesafio.SetActive(true);
            }

            gameObject.SetActive(false);
        }

    }
}
