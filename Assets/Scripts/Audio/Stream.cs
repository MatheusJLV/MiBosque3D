using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Stream : MonoBehaviour
{
    /*void Start()
    {
        StartCoroutine(PlayTTS());
    }

    IEnumerator PlayTTS()
    {
    /*using(UnityWebRequest music = UnityWebRequestMultimedia.GetAudioClip("http://a6.radioheart.ru:8012/live", AudioType.MPEG))
    {
        yield return music.SendWebRequest();

        if (music.isNetworkError)
        {
            Debug.Log(music.error);
        }
        else
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(music);
            Debug.Log(clip + " length: " + clip.length);
            if (clip)
            {
                GetComponent<AudioSource>().clip = clip;
                GetComponent<AudioSource>().Play();
            }
        }
    }*/
    

        /*using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("http://200.126.14.250:8000/station1.ogg", AudioType.OGGVORBIS))
        {
            DownloadHandlerAudioClip dHA = new DownloadHandlerAudioClip(string.Empty, AudioType.OGGVORBIS);
            dHA.streamAudio = true;
            www.downloadHandler = dHA;
            www.SendWebRequest();
            while (www.downloadProgress < 1)
            {
                //Debug.Log(www.downloadProgress);
                yield return new WaitForSeconds(.1f);
            }
            if (www.isNetworkError)
            {
                Debug.Log("error");
            }
            else
            {
                GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>().clip = dHA.audioClip;
                GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioSource>().Play();
            }
        }*/
        /*using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("http://ia800207.us.archive.org/25/items/abird2005-02-10/abird2005-02-10t02.ogg", AudioType.OGGVORBIS))
        {

            var synRes = www.SendWebRequest();
            yield return synRes;

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip stream_music = DownloadHandlerAudioClip.GetContent(www);
                GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().clip = stream_music;
                GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().Play();
            }
        }

    }*/

}
