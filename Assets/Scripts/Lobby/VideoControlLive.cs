using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;


public class VideoControlLive : MonoBehaviour
{
    public VideoPlayer VPlayer;

    public FirstPersonController fpsController;

    Transform transf;

     // Start is called before the first frame update
    void Start()
    {
        transf = this.gameObject.transform;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VPlayer.Play();
            fpsController.canRotate = false;
            //fpsController.transform.position = new Vector3(268.668f, 260.464f, 121.438f);
            //fpsController.transform.localEulerAngles = new Vector3(0, 0, 0);
            //fpsController.gameObject.transform.GetChild(0).localEulerAngles = new Vector3(0, 0, 0);
            fpsController.gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            fpsController.gameObject.transform.GetChild(0).localEulerAngles = new Vector3(-3.0f, 90.0f, 0);
            fpsController.gameObject.transform.GetChild(0).GetComponent<Camera>().fieldOfView = 65.0f;
            fpsController.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            VPlayer.Stop();
            fpsController.canRotate = true;
            fpsController.enabled = true;
        }
    }
}
