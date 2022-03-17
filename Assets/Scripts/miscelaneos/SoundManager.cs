using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using System;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {

	public int station;
	public Text prueba;
	[DllImport("__Internal")]
    private static extern void StartAudio(int station_id);
	[DllImport("__Internal")]
	private static extern void StopAudio();

	void Start(){
		PlayAudio(MapManager.diccionarioID[GameManager.instance.currentStation]);
	}

	public void PlayAudio(int id){
		try {
			StartAudio(id);
            Debug.Log("audio cargado");
		} catch (EntryPointNotFoundException e) {
			Debug.Log("No se pudo cargar audio");
			Debug.Log(e.StackTrace);
		}
	}

	public void PauseAudio(){

        try
        {
            StopAudio();
        }
        catch (EntryPointNotFoundException e)
        {
            Debug.Log("No se pudo cargar audio");
            Debug.Log(e.StackTrace);
        }
        
	}
}
