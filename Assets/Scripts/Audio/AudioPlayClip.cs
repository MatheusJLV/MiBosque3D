using UnityEngine;

public class AudioPlayClip : MonoBehaviour {
    [SerializeField] AudioClip audioToPlay;

    public void playAudio(){
        AudioSourceSFX.instance.PlaySound(audioToPlay);
    }
}