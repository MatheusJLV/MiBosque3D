using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;

using System;
using Newtonsoft.Json.Linq;

public class ChallengePass5 : MonoBehaviour
{
    public GameObject dialogoDesafioCompleto, dialogoDesafioPendiente, dialogoDesafioFallado, recordatorio;
    public AudioVocals audioVocals;
    public GameObject LogroSist;
    bool act = true;
    public GameObject fpscontroller;
    public String New_Scene;
    public static DateTime inicio;
    private int levelId = -1;
    void Update()
    {
        if (WaterVerification.fuegoApagado && act)
        {
            Player.instance.playerData.finishedGame = true;
            fpscontroller.GetComponent<Player>().gainEXP(4);
            LogroSist.GetComponent<LogrosGlobales>().ProgresarLogro(3);
            LogroSist.GetComponent<LogrosGlobales>().ProgresarMision(3, "Apagar la fogata");
            act = false;
            ChallengePass6.inicio = DateTime.Now;
            audioVocals.reproducirAlt();
            Player.instance.playerData.misiones[3] = true;
            Mision mision = (LogroSist.GetComponent<LogrosGlobales>()).misiones[3];
            if (!GameManager.OfflineMode)
            {
                Peticiones.instance.registerPlayerMission(mision.nombre, Player.instance.playerData, inicio.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                Peticiones.instance.registerFinishMission(Player.instance.playerData, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), this.levelId);
            }
           
            Player.instance.playerData.logros[3] = DateTime.Now.ToString();
            if (!GameManager.OfflineMode)
            {
                Peticiones.instance.registerPlayerPrize((LogroSist.GetComponent<LogrosGlobales>()).logros[3].nombre, Player.instance.playerData);

            }
            SaveProfile.instance.SaveGame();
            dialogoDesafioCompleto.SetActive(true);
            dialogoDesafioPendiente.SetActive(false);
            dialogoDesafioFallado.SetActive(false);
            recordatorio.SetActive(false);
            CreateStadistics();
            

        }
    }

    public void sendStartReq()
    {
        inicio = DateTime.Now;
        try
        {
            if (!GameManager.OfflineMode)
            {
                JObject res = Peticiones.instance.registerStartMission("Bosque-Estación 6", Player.instance.playerData, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                if (res["payload"]["GameLevelInstanceId"] != null)
                {
                    levelId = (int)res["payload"]["GameLevelInstanceId"];
                }
            }
            
        }
        catch
        {
            Debug.Log("Error al registrar inico de nivel.");
        }
    }

    public void CreateStadistics(){
        Debug.Log("Creando estadísticas...");
        StadisticsData.Stadistics tmp1 = new StadisticsData.Stadistics("mission_data");
        string name = LogroSist.GetComponent<LogrosGlobales>().misiones[3].nombre;
        StadisticsData.DataMission dat1 = new StadisticsData.DataMission(inicio,name);
        tmp1.data = dat1;
        string json = JsonConvert.SerializeObject(tmp1,Formatting.Indented);
        GameManager.instance.CallEnumerator(json);
        GameManager.estas.lista.Add(tmp1);
        //
        StadisticsData.Stadistics tmp2 = new StadisticsData.Stadistics("experiencie_data");
        StadisticsData.DataExperiencie dat2 = new StadisticsData.DataExperiencie(5);
        tmp2.data = dat2;
        string json2 = JsonConvert.SerializeObject(tmp2,Formatting.Indented);
        GameManager.instance.CallEnumerator(json);
        GameManager.estas.lista.Add(tmp2);
        //
        StadisticsData.Stadistics tmp3 = new StadisticsData.Stadistics("prize_data");
        string prize = LogroSist.GetComponent<LogrosGlobales>().logros[3].nombre;
        StadisticsData.DataPrize dat3 = new StadisticsData.DataPrize(prize);
        tmp3.data = dat3;
        string json3 = JsonConvert.SerializeObject(tmp3,Formatting.Indented);
        GameManager.instance.CallEnumerator(json3);
        GameManager.estas.lista.Add(tmp3);
        //cambio de escena
        Debug.Log("Cambiando a final...");
        Invoke("cambio_a_final", 4);
    }
    public void cambio_a_final()
    {
        SceneManager.LoadScene(New_Scene);
    }

}
