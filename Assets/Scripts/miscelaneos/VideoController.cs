using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityStandardAssets.Characters.FirstPerson;

public class VideoController : MonoBehaviour
{
    private bool activeWindow;
    public GameObject canvasVideo;
    private int contador;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PlayVideo");
        contador = 0;
    }

    private void Update()
    {
        if(contador == 16)
        {
            stopAndContinue();
            Destroy(this);
        }
    }
    public void stopAndContinue()
    {
        transform.GetComponent<VideoPlayer>().Stop();
        gameObject.SetActive(false);
        canvasVideo.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = true;
    }

    IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(4f);

        canvasVideo.SetActive(true);
        transform.GetComponent<VideoPlayer>().Play();
        GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<MouseController>().enabled = false;

        while (contador < 16)
        {
            Debug.Log(contador);
            yield return new WaitForSeconds(1f);
            contador += 1;
        }
        


    }
}
