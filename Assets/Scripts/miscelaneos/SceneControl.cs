using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject actionLogger;
    private void Start()
    {
        actionLogger = GameObject.Find("ActionLogger");
    }
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void changeScene(string name)
    {
        if (name== "MenuPartidas")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            actionLogger.GetComponent<ActionLogger>().actionLogger.locacion = "Menu Partida";
        }
        SceneManager.LoadScene(name);
    }
}
