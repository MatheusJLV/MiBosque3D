using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ShowBook : MonoBehaviour
{

    public Canvas bookCanvas;
    public GameObject bookIcon;
    public GameObject salidaLibro;
    private FirstPersonController firstPersonController;
    public bool isCanvasActive;

    public GameObject cerrarLibro;
    public GameObject CanvasPlayerGUI;

    private void Start()
    {
#if UNITY_STANDALONE_WIN || UNITY_STANDALONE
        cerrarLibro.SetActive(false);
        bookIcon.SetActive(true);
#endif
        bookCanvas.gameObject.SetActive(false);
#if UNITY_ANDROID || UNITY_IOS
        bookIcon.SetActive(false);
#endif
        salidaLibro.SetActive(false);
        isCanvasActive = false;
        firstPersonController=GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
        Player.instance.playerData.libroDesbloqueado=true;
    }

    public void displayBook()
    {
        if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            BookPages.instance.isOpen = true;
            //BookPages.instance.cargarLibro();
            MenuPausa.instance.Pausar();
            bookCanvas.gameObject.SetActive(true);
            salidaLibro.SetActive(true);
            isCanvasActive = true;
            Time.timeScale = 0f;
#if UNITY_ANDROID || UNITY_IOS
        CanvasPlayerGUI.SetActive(false);
        GameObject.Find("FPSController").GetComponent<JoystickController>().enabled = false;
        salidaLibro.SetActive(false);
#endif
        }
    }

    public void exitBookCanvas()
    {
#if UNITY_ANDROID || UNITY_IOS
        CanvasPlayerGUI.SetActive(true);
        GameObject.Find("FPSController").GetComponent<JoystickController>().enabled = true;
        GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>().handle.anchoredPosition = Vector2.zero;
        GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>().input = Vector2.zero;
#endif
        BookPages.instance.isOpen = false;
        BookPages.instance.pagesLoaded = false;

        Time.timeScale = 1f;
        bookCanvas.gameObject.SetActive(false);
        salidaLibro.SetActive(false);
        MenuPausa.instance.Reanudar();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        isCanvasActive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!isCanvasActive)
            {
                Debug.Log("Aplasto L y el canvas no esta Activo.");
                displayBook();
            }
            else
            {
                exitBookCanvas();
            }

        }
    }

}
