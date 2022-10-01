using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class EnableMouse : MonoBehaviour
{

    private Rect screenRect;
    public FirstPersonController fpsController;
    public GameObject controlerObj;

    Transform transf;
    public bool mochila = false;

    // Start is called before the first frame update
    void Start()
    {
        transf = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    
                }
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fpsController.canRotate = false;
            fpsController.transform.position = transf.position;
            fpsController.transform.localEulerAngles = new Vector3(0, 0, 0);
            fpsController.gameObject.transform.GetChild(0).localEulerAngles = new Vector3(-3.0f, 0, 0);
            fpsController.gameObject.transform.GetChild(0).GetComponent<Camera>().fieldOfView = 70.0f;
            screenRect = new Rect(0, 0, Screen.width, Screen.height);
            fpsController.enabled = false;
        }
        if (mochila)
        {
            controlerObj.GetComponent<ShowMochila>().mochilaInt(true);
        }
    }

    public void mouseRecover()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            fpsController.canRotate = false;
            fpsController.transform.position = transf.position;
            fpsController.transform.localEulerAngles = new Vector3(0, 0, 0);
            fpsController.gameObject.transform.GetChild(0).localEulerAngles = new Vector3(-3.0f, 0, 0);
            fpsController.gameObject.transform.GetChild(0).GetComponent<Camera>().fieldOfView = 70.0f;
            screenRect = new Rect(0, 0, Screen.width, Screen.height);
            fpsController.enabled = false;
      }
    public void OnDestroy()
    {
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fpsController.canRotate = true;
            screenRect = new Rect(0, 0, Screen.width, Screen.height);
            fpsController.enabled = true;
        }
        if (mochila)
        {
            controlerObj.GetComponent<ShowMochila>().mochilaInt(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            fpsController.canRotate = true;
            screenRect = new Rect(0, 0, Screen.width, Screen.height);
            fpsController.enabled = true;
        }
        if (mochila)
        {
            controlerObj.GetComponent<ShowMochila>().mochilaInt(false);
        }
    }
}
