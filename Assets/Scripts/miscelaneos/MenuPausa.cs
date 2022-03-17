﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class MenuPausa : MonoBehaviour
{
    public float countdown;
    private Collider cameraBlocker;
    public static bool IsPaused = false;
    public static bool IsPausedByOtherCanvas = false;

    public GameObject MenuPausaUI, panelEstrellas, Panel;
    public SceneChanger sceneChanger;
    private FirstPersonController fpscontroller;
    public static MenuPausa instance;
    private MouseController mouseController;
    [SerializeField] private AudioMixerSnapshot PausedSnapshot;
    [SerializeField] private AudioMixerSnapshot UnpausedSnapshot;
    [SerializeField] private float fadeTime=1.0f;

    private void Awake()
    {
        instance = this;
        cameraBlocker = GameObject.FindGameObjectWithTag("Blocker").GetComponent<Collider>();

    }
    private void Start()
    {
        fpscontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        mouseController = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>();
        sceneChanger.gameObject.SetActive(true);
    }

    void Update()
    {
        if (countdown > 0)
        {
            countdown = countdown - Time.deltaTime;
        }
        else if (countdown < 0)
        {
            countdown = 0;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (IsPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

    }

    public void Pausar()
    {
        fpscontroller.enabled = false;
        mouseController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Debug.Log("1P "+IsPausedByOtherCanvas);
        IsPausedByOtherCanvas=true;
        Debug.Log("2P "+IsPausedByOtherCanvas);
        PausedSnapshot.TransitionTo(fadeTime);
        cameraBlocker.enabled=true;
        countdown = 5;

    }
    
    public void Reanudar()
    {
        fpscontroller.enabled = true;
        Debug.Log("1R "+IsPausedByOtherCanvas);
        IsPausedByOtherCanvas=false;
        Debug.Log("2R "+IsPausedByOtherCanvas);
        UnpausedSnapshot.TransitionTo(fadeTime);
        cameraBlocker.enabled=false;
    }

    public void ResumeGame()
    {
        fpscontroller.enabled = true;

        if(!IsPausedByOtherCanvas){
            mouseController.enabled=true;
            UnpausedSnapshot.TransitionTo(fadeTime);
            cameraBlocker.enabled=false;
        }
        Time.timeScale = 1f;
        IsPaused = false;
        MenuPausaUI.SetActive(false);
        Panel.SetActive(true);
    }

    public void PauseGame()
    {
        PausedSnapshot.TransitionTo(fadeTime);
        fpscontroller.enabled = false;
        mouseController.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MenuPausaUI.SetActive(true);
        Panel.SetActive(false);
        IsPaused = true;
        Time.timeScale = 0f;
        cameraBlocker.enabled=true;
    }

    public void MenuMapa()
    {
        UnpausedSnapshot.TransitionTo(fadeTime);
        IsPaused = false;
        Time.timeScale = 1f;
        //GameObject.Find("Audio").GetComponent<SoundManager>().PauseAudio();
        sceneChanger.FadeToLevel(GameManager.instance.currentStation);
    }

    public void Lobby()
    {
        UnpausedSnapshot.TransitionTo(fadeTime);
        IsPaused = false;
        Time.timeScale = 1f;
        //GameObject.Find("Audio").GetComponent<SoundManager>().PauseAudio();
        GameManager.instance.scene = 2;
        sceneChanger.FadeToLevel(0);

    }

    public void MenuInicial(string name)
    {
        UnpausedSnapshot.TransitionTo(fadeTime);
        IsPaused = false;
        Time.timeScale = 1f;
        GameManager.instance.scene=0;
        //GameObject.Find("Audio").GetComponent<SoundManager>().PauseAudio();
        SceneManager.LoadScene(name);
    }
}
