using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class API : MonoBehaviour
{
    //api/Institution/list
    private const string URL = "www.google.ca";
    public Text responseText;


    // Use this for initialization
   public void Request()
    {

        WWW request = new WWW(URL);
        StartCoroutine(OnResponse(request));
        Debug.Log(request.text); 

    }

    private IEnumerator OnResponse(WWW req)
    {
        yield return req;

        responseText.text = req.text;
    }
    
}
