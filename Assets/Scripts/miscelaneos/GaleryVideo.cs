using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class GaleryVideo : MonoBehaviour
{
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI cuerpo;
    public RawImage imagen;
    public RawImage ivideo;
    public Image mask;
    public Button sound;
    public Button nsound;
    public Button left;
    public Button right;
    public Button video;
    public VideoPlayer player;
    public AudioSource audio;
    AudioSource audio2;
    public Button playPause;
    public Button exit;
    public Sprite play;
    public Sprite pause;
    public Button mute;
    public Button unmute;

    //public GameObject videoPlay;
    // Start is called before the first frame update
    void Start()
    {
        audio2 = GetComponent<AudioSource>();
#if UNITY_ANDROID || UNITY_IOS
        GameObject.Find("VideoGaleria").GetComponent<RectTransform>().sizeDelta = new Vector2(480,300);
        GameObject.Find("PlayPause").GetComponent<RectTransform>().localPosition = new Vector3(-205f, -145f, 0f);
        GameObject.Find("ExitVideo").GetComponent<RectTransform>().localPosition = new Vector3(200f, 100f, 0f);
#endif
    }

    // Update is called once per frame
    void Update()
    {
        player.Prepare();
    }

    public void PlayVideo()
    {
        StartCoroutine(Play());
    }

    public IEnumerator Play(){
        cuerpo.enabled=false;
        titulo.enabled=false;
        imagen.enabled=false;
        mask.enabled=false;
        sound.image.enabled=false;
        nsound.image.enabled=false;
        video.image.enabled=false;
        left.image.enabled=false;
        right.image.enabled=false;
        sound.interactable=false;
        nsound.interactable=false;
        video.interactable=false;
        left.interactable=false;
        right.interactable=false;
        ivideo.enabled=true;
        playPause.image.enabled=true;
        playPause.interactable=true;
        exit.image.enabled=true;
        exit.interactable=true;
        mute.image.enabled = true;
        mute.interactable = true;
        unmute.image.enabled = true;
        unmute.interactable = true;

        WaitForSeconds wfs = new WaitForSeconds(1);
        while (!player.isPrepared)
        {
            Debug.Log("Aquii"+player.isPrepared);
            yield return wfs;
            break;
        }
        ivideo.texture = player.texture;
        player.Play();
        audio.panStereo = 0.0f;  //Convierte el sonido del video en Stereo -->  1.0f para solo oído derecho, 0.0f para un punto medio, -1.0f para solo oído izquierdo
        audio.Play();
        playPause.image.sprite = pause;
    } 

    public void PlayPause() {
        if(player.isPlaying) {
            playPause.image.sprite = play;
            player.Pause();
            audio.Pause();
        } else if (!player.isPlaying) {
            playPause.image.sprite = pause;
            player.Play();
            audio.panStereo = 0.0f;  //Convierte el sonido del video en Stereo -->  1.0f para solo oído derecho, 0.0f para un punto medio, -1.0f para solo oído izquierdo
            audio.Play();
        }
    }

    public void Mute()
    {
        player.SetDirectAudioMute(0,true);
    }

    public void PlaySound()
    {
        player.SetDirectAudioMute(0, false);
    }

    public void CloseVideo(){
        player.Stop();
        audio.Stop();
        cuerpo.enabled=true;
        titulo.enabled=true;
        imagen.enabled=true;
        mask.enabled=true;
        ivideo.enabled=false;
        playPause.image.enabled=false;
        playPause.interactable=false;
        exit.image.enabled=false;
        exit.interactable=false;
        mute.image.enabled = false;
        mute.interactable = false;
        unmute.image.enabled = false;
        unmute.interactable = false;
        sound.image.enabled=true;
        nsound.image.enabled=true;
        video.image.enabled=true;
        left.image.enabled=true;
        right.image.enabled=true;
        sound.interactable=true;
        nsound.interactable=true;
        video.interactable=true;
        left.interactable=true;
        right.interactable=true;
    }
}
