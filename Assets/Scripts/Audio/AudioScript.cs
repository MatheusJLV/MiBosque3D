using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip sound;

    private void Start()
    {
        source.clip = sound;

    }
    public void reproucir()
    {
        if (source.isPlaying)
        {
            source.Play();
        }
        else
        {
            source.Stop();
        }
    }

    public void reproducir()
    {
        source.Play();
    }
    public void reanudar()
    {
        source.UnPause();
    }

    public void detener()
    {
        source.Pause();

    }
}
