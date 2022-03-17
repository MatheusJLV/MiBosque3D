using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;



public class RestClient : MonoBehaviour {

    private static RestClient _instance;

    public static RestClient Instance
    {
        get
        {
            if(_instance == null)
            {
                GameObject go = new GameObject();
                go.name = typeof(RestClient).Name;
                _instance = go.AddComponent<RestClient>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    //public IEnumerator Get(string url, System.Action<PreguntaObjectList> callBack)
    public void Get(System.Action<PreguntaObjectList> callBack)
    {
        /*using (UnityWebRequest www = UnityWebRequest.Get(url))
        {

            yield return www.SendWebRequest();

            if(www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if(www.isDone)
                {
                    string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                    Debug.Log(url);
                    Debug.Log(jsonResult);
                    PreguntaObject[] preguntaList = JsonHelper.getJsonArray<PreguntaObject>(jsonResult);
                    List<PreguntaObject> lista = new List<PreguntaObject>(preguntaList);
                    PreguntaObjectList lista_final = new PreguntaObjectList
                    {
                        preguntas = lista
                    };
                    //lista_final.preguntas = lista;

                    callBack(lista_final);
                }

            }
        }*/
        string jsonResult = Resources.Load<TextAsset>("Questions/questions").text;
        Debug.Log(jsonResult);
        PreguntaObject[] preguntaList = JsonHelper.GetJsonArray<PreguntaObject>(jsonResult);
        List<PreguntaObject> lista = new List<PreguntaObject>(preguntaList);
        PreguntaObjectList lista_final = new PreguntaObjectList
        {
            preguntas = lista
        };
        callBack(lista_final);
    }
}
