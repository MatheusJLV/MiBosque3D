using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioVocals : MonoBehaviour {
    private AudioSource audioSource;
    public AudioClip[] vocals;

    private int vlength;

    private void Awake() {
        audioSource=GetComponent<AudioSource>();
    }
    private void Start() {
        vlength=vocals.Length;
    }

    public void reproducirAlt(){
        int ind=Random.Range(0,vlength);
        audioSource.clip=vocals[ind];
        audioSource.Play();
    }
}