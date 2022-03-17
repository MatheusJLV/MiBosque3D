using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DataApi;
using Newtonsoft.Json;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


namespace ApiJsonSpace
{

    public class ApiJson : MonoBehaviour
    {
        //api/Institution/list
        private const string URL = "http://200.126.14.250:8080/";
        public List<DataInstituciones> institucionesObject;
        public InputField colegio;
        public GameObject unidadEducativaPanel;
        public GameObject ingresoID;
        private string reqInstituciones;
        private string unidadEducativa;
        public Text unidadEducativaid;
        private string idPlayer;
        

        // Use this for initialization
        public void Request()
        {
            string urlInstutucines = URL + "api/Institution/list";
            StartCoroutine(OnResponse(urlInstutucines));
 
        }

        private IEnumerator OnResponse(string path)
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
                reqInstituciones = req.downloadHandler.text;
                var instituciones = JsonConvert.DeserializeObject<List<DataInstituciones>>(reqInstituciones);
                institucionesObject = instituciones;
                Debug.Log(instituciones.Count);
                

             
            }




        }

        public void activateIngresoId() {

            

        }

  
        public void setDataPlayer(PlayerData playerData) {
            playerData.SetPlayerData(playerData.nombre, playerData.genero, playerData.edad, playerData.unidadEducativa, playerData.personajeSeleccionado);
        }

        public void nextToVideo() {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }


       

    }

}
