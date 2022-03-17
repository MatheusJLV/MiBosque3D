using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using DataApi;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.IO;





public class ApiJsonEstudiante : MonoBehaviour
    {
        //api/Institution/list
        private const string URL = "http://200.126.14.250:8080/";
        public List<Estudiante> estudiantesObject;
        public InputField ingresoID;
        private string reqEstudiantes;
        public Text unidadEducativaid;
        private string idPlayer;


    // Use this for initialization
    public void Request()
        {
       
            string urlestudiantes = URL + "institution/" + unidadEducativaid.text + "/students";
            StartCoroutine(OnResponseEs(urlestudiantes));
          

        }

        private IEnumerator OnResponseEs(string path)
        {
            UnityWebRequest req = new UnityWebRequest(path);
            req.downloadHandler = new DownloadHandlerBuffer();
            yield return req.SendWebRequest();

            if (req.isNetworkError)
            {
                Debug.Log(req.error);
            }
            else
            {
                // Show results as text
                reqEstudiantes = req.downloadHandler.text;
                nextToVideo();
                var estudiantes = JsonConvert.DeserializeObject<List<Estudiante>>(reqEstudiantes);
                estudiantesObject = estudiantes;
                

                foreach (Estudiante estudiante in estudiantes)
                {
                    if (estudiante.user.ToString() == ingresoID.text)
                    {
                        dataEstudiante dataEs = new dataEstudiante();
                        dataEs.id = estudiante.id;
                        dataEs.idCollegue = unidadEducativaid.text;
                        dataEs.idPlayer = estudiante.player;
                        string jason = JsonUtility.ToJson(dataEs);
                        File.WriteAllText("dataEstudiantes.JSON", jason);
                        Debug.Log(reqEstudiantes);

                    }
                }
            }

        nextToVideo();
    }

    public void nextToVideo()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private class dataEstudiante
    {
        public string id;
        public string idPlayer;
        public string idCollegue;
    }


}


