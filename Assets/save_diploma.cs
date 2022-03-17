using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class save_diploma : MonoBehaviour
{
    public GameObject notifDiploma;
    public Text route;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        Debug.Log(Application.dataPath);
        string sourceFile = Application.dataPath + "/Sprites/CertificadoDigital.png";
        string localfolder = Application.dataPath;
        var array = localfolder.Split('/');
        var username = array[2];
        string destinationFile = "C:/Users/" + username + "/Downloads/Certificado" + Player.instance.playerData + ".png";
        try
        {
            File.Copy(sourceFile, destinationFile, true);
            route.text = destinationFile;
            StartCoroutine(feedback());
        }
        catch (IOException iox)
        {

            Debug.Log(iox.Message);
        }
        destinationFile = "D:/Users/" + username + "/Downloads/Certificado" + Player.instance.playerData.nombre + ".png";
        try
        {
            File.Copy(sourceFile, destinationFile, true);
            route.text = destinationFile;
            StartCoroutine(feedback());
        }
        catch (IOException iox)
        {

            Debug.Log(iox.Message);
        }
    }

    IEnumerator feedback()
    {
        notifDiploma.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        notifDiploma.SetActive(false);
    }
}
