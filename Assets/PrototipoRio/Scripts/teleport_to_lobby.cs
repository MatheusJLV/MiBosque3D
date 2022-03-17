using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class teleport_to_lobby : MonoBehaviour
{

    AsyncOperation operation;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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

                yield return null;
            }
        }
        else
        {
            GameManager.instance.scene = 0;
            operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 3);
            Debug.Log("ESCENA A MAPA");
        }

    }

}
