using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimizarVideos : MonoBehaviour
{
    public GameObject video;

    public void OnMouseDown()
    {
        Debug.Log("minimizando");
        video.SetActive(false);
        /*video.transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        video.transform.localPosition= video.transform.localPosition + new Vector3(100, 0, 0);*/
       
        //Destroy(this);
    }
    /*// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
