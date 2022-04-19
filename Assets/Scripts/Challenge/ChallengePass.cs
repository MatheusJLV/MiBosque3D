using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ChallengePass : MonoBehaviour
{

    public static DateTime inicio = DateTime.Now;
    public GameObject dialogoDesafioCompleto;
    public GameObject dialogoDesafioPendiente;

    public GameObject ardilla;
    public GameObject iguana;
    public GameObject pepiche;

    public GameObject feedback;
    public Text message;
    public bool empezado;
    public AudioVocals audioVocals;
    bool restric = false;
    private bool sent=false;
    private int levelId = -1;
    public GameObject LogroSist;

    public GameObject fpscontroller;

    //public GameObject actionLogger;

    void Start()
    {
        //actionLogger = GameObject.Find("ActionLogger");
        /*if (Player.instance.playerData.maxStation <2)
        Debug.Log("estacion maxima "+Player.instance.playerData.maxStation);
        {
            actionLogger.GetComponent<ActionLogger>().actionLogger.agregarAccion("Begin Bosque mision", "" + 1);
        }*/
        
    }

    private void Update()
    {
        
        restric = ardilla.activeSelf || iguana.activeSelf || pepiche.activeSelf;

        if (ardilla.activeSelf != iguana.activeSelf || iguana.activeSelf != pepiche.activeSelf ||ardilla.activeSelf != pepiche.activeSelf)
        {
            empezado = true;
        }

        if (!restric == true)
        {
            dialogoDesafioPendiente.SetActive(false);
            dialogoDesafioCompleto.SetActive(true);
            Player.instance.playerData.misiones[0] = true;
            Mision mision = (LogroSist.GetComponent<LogrosGlobales>()).misiones[0];
            
            Player.instance.playerData.logros[0] = DateTime.Now.ToString();

            

            if (empezado){
                StartCoroutine(ShowFeedback());
                if (!sent)
                {
                    Debug.Log("enviando estadísticas de final de misión...");
                    Debug.Log(Peticiones.instance.registerPlayerMission(mision.nombre, Player.instance.playerData, inicio.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")));
                    if (!GameManager.OfflineMode)
                    {
                        Debug.Log("Intento con online1");
                        Peticiones.instance.registerPlayerPrize(LogroSist.GetComponent<LogrosGlobales>().logros[0].nombre, Player.instance.playerData);
                    }
                    sent = true;
                    ChallengePass3.inicio = DateTime.Now;
                }
            }
        }
        else {

            dialogoDesafioPendiente.SetActive(true);
            dialogoDesafioCompleto.SetActive(false);
        }
    }

    public void sendStartReq()
    {
        inicio = DateTime.Now;
        Debug.Log("Offline Mode: " + GameManager.OfflineMode);
        try
        {
            if (!GameManager.OfflineMode)
            {
                Debug.Log("Intento con online1");
                JObject res = Peticiones.instance.registerStartMission("Bosque-Estación 1", Player.instance.playerData, inicio.ToString("yyyy-MM-dd hh:mm:ss"));

            
            if (res["payload"]["GameLevelInstanceId"] != null)
            {
                levelId =(int) res["payload"]["GameLevelInstanceId"];
            }
            }
        }
        catch
        {
            Debug.Log("Error al registrar inico de nivel.");
        }
    }

    IEnumerator ShowFeedback()
    {
        //actionLogger.GetComponent<ActionLogger>().actionLogger.agregarAccion("Finish Bosque mision", "" + 1);
        LogroSist.GetComponent<LogrosGlobales>().ProgresarLogro(0);
        fpscontroller.GetComponent<Player>().gainEXP(3);
        Peticiones.instance.registerFinishMission(Player.instance.playerData, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), this.levelId);
        message.text = "Gran trabajo, avanza hasta el final de la estación";
        empezado = false;
        yield return new WaitForSeconds(1.0f);
        feedback.SetActive(true);
        audioVocals.reproducirAlt();
        yield return new WaitForSeconds(2.0f);
        feedback.SetActive(false);
        CreateStadistics();
    }

    public void CreateStadistics(){
        Debug.Log("Creando estadísticas...");
        StadisticsData.Stadistics tmp1 = new StadisticsData.Stadistics("mission_data");
        string name = LogroSist.GetComponent<LogrosGlobales>().misiones[0].nombre;
        StadisticsData.DataMission dat1 = new StadisticsData.DataMission(inicio,name);
        tmp1.data = dat1;
        string json = JsonConvert.SerializeObject(tmp1,Formatting.Indented);
        GameManager.instance.CallEnumerator(json);
        GameManager.estas.lista.Add(tmp1);
        //
        StadisticsData.Stadistics tmp2 = new StadisticsData.Stadistics("experiencie_data");
        StadisticsData.DataExperiencie dat2 = new StadisticsData.DataExperiencie(3);
        tmp2.data = dat2;
        string json2 = JsonConvert.SerializeObject(tmp2,Formatting.Indented);
        GameManager.instance.CallEnumerator(json);
        GameManager.estas.lista.Add(tmp2);
        //
        StadisticsData.Stadistics tmp3 = new StadisticsData.Stadistics("prize_data");
        string prize = LogroSist.GetComponent<LogrosGlobales>().logros[0].nombre;
        StadisticsData.DataPrize dat3 = new StadisticsData.DataPrize(prize);
        tmp3.data = dat3;
        string json3 = JsonConvert.SerializeObject(tmp3,Formatting.Indented);
        GameManager.instance.CallEnumerator(json3);
        GameManager.estas.lista.Add(tmp3);
        Debug.Log("Estadisticas creadas");
    }


    public void Empezar()
    {
        empezado = true;
    }

}
