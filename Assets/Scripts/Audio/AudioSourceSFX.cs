using UnityEngine;
/**
Class used to reproduce sound effect (ui interaction, in general)
*/
public class AudioSourceSFX : MonoBehaviour {
    public static AudioSourceSFX instance;
    private AudioSource audioSource;
    private void Awake() {
        if(instance)
            Destroy(this.gameObject);
        else{
            instance=this;
            DontDestroyOnLoad(this.gameObject);
        }

        audioSource=GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip audio){
        audioSource.clip=audio;
        audioSource.Play();
    }
}