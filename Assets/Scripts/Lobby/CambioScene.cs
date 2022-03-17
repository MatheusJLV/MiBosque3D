using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CambioScene : MonoBehaviour
{
    public Image img;
   AsyncOperation operation;
    public Slider slider;
    public Text progressText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            img.enabled = true;
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);

        }
    }


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

    }



}
