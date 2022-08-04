using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class TriggerVideo : MonoBehaviour
{

    public VideoPlayer video;
    public Animator videoAnim;
    public GameObject CanvasJoysticks;
    private NotificarLogros NL;
    // Start is called before the first frame update

    void Start() {
        video.loopPointReached += EndReached;
        NL = GameObject.Find("NotifLogros").GetComponent<NotificarLogros>();
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
#if UNITY_ANDROID || UNITY_IOS
        CanvasJoysticks.SetActive(true);
#endif
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        GetComponent<Collider>().enabled=false;
        videoAnim.SetBool("Active", false);
        MenuPausa.instance.Reanudar();
    }
    // Update is called once per frame
    /*void Update()
    {

    }*/

    private void OnTriggerEnter(Collider other)
    {
#if UNITY_ANDROID || UNITY_IOS
        CanvasJoysticks.SetActive(false);
#endif
        MenuPausa.instance.Pausar();
        videoAnim.SetBool("Active", true);
        video.Play();
        Destroy(this.GetComponent<BoxCollider>());
        NL.cerrar();
    }
   


}
