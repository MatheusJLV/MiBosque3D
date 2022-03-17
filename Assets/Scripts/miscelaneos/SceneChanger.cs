using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour {

	public Animator animator;
	public int scene;
	public int stationToLoad;
	public GameObject LoadingScreen;
	public Slider slider;
	public Text progressText;
    //public GameObject guia;
	public static bool videoreproducido=false;

	private void Start(){
		scene = 0;
	}

	public void FadeToLevel(int station){
		stationToLoad = station;
		GameManager.instance.SetCurrentStation(station);
        //guia.SetActive(false);
		animator.SetTrigger("fade_out");
	}

	public void LoadingLevel(){
		StartCoroutine(OnFadeComplete());
	}

	public IEnumerator OnFadeComplete(){
		AsyncOperation operation;
		/*
		if(videoreproducido == false){

			if (GameManager.instance.scene == 0){
			GameManager.instance.scene = 1;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
			Debug.Log("ESCENA A BOSQUE");
			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .9f);
				slider.value = progress;
				progressText.text = progress * 100f + "%";

				yield return null;
			}
		} 


		}else{

			if (GameManager.instance.scene == 0){
			GameManager.instance.scene = 1;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 2);
			Debug.Log("ESCENA A BOSQUE");
			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .9f);
				slider.value = progress;
				progressText.text = progress * 100f + "%";

				yield return null;
			}
		} else {
			GameManager.instance.scene = 0;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 2);
			Debug.Log("ESCENA A MAPA");
		}

		}*/

	

		if (GameManager.instance.scene == 0){
			GameManager.instance.scene = 1;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
			Debug.Log("ESCENA A BOSQUE");
			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .9f);
				slider.value = progress;
				progressText.text = progress * 100f + "%";

				yield return null;
			}
        }
        else if (GameManager.instance.scene == 2)
        {
            GameManager.instance.scene = 0;
            operation = SceneManager.LoadSceneAsync("Lobby");
        } else {
			GameManager.instance.scene = 0;
			operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
			Debug.Log("ESCENA A MAPA");
		}

	}

    public void NextScene(string name)
    {
        SceneManager.LoadScene(name);

    }
}
