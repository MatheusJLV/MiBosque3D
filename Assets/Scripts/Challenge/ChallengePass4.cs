
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ChallengePass4 : MonoBehaviour
{

    public GameObject dialogoDesafioCompleto, dialogoDesafioPendiente;
    public GameObject food;
    public PlateFood plateFood;
    public GameObject haloPlato;
    public GameObject recordatorio;
    public GameObject LogroSist;
    public AudioVocals audioVocals;
    public GameObject fpscontroller;
    private int levelId = 3;
    bool act = true;
    public GameObject cage;
    public static DateTime inicio;

    private void Update()
    {
        if (plateFood.lleno && act)
        {
            fpscontroller.GetComponent<Player>().gainEXP(4);
            LogroSist.GetComponent<LogrosGlobales>().ProgresarLogro(2);
            LogroSist.GetComponent<LogrosGlobales>().ProgresarMision(2, "Alimentar al Gavilan");
            dialogoDesafioPendiente.SetActive(false);
            dialogoDesafioCompleto.SetActive(true);
            Player.instance.playerData.misiones[2] = true;
            ChallengePass5.inicio = DateTime.Now;
            Mision mision = (LogroSist.GetComponent<LogrosGlobales>()).misiones[2];
            if (!GameManager.OfflineMode)
            {
                Debug.Log("el level id es ----------------- " + this.levelId);
                Peticiones.instance.registerPlayerMission(mision.nombre, Player.instance.playerData, inicio.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                Peticiones.instance.registerFinishMission(Player.instance.playerData, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), this.levelId);
            }
            else
            {

                ActionLogger ac = GameObject.Find("ActionLogger").GetComponent<ActionLogger>();
                if (!GameManager.OfflineMode)
                {
                    ac.actionLogger.agregarAccion("Settings", "Offline");
                }

                ac.actionLogger.online = false;
                ac.actionLogger.agregarPeticion("mision", mision.nombre, Player.instance.playerData.Token, inicio.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                ac.actionLogger.agregarPeticion("finish mision", "" + this.levelId, Player.instance.playerData.Token, null, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                try
                {
                    ac.GetComponent<ActionLogger>().actionLogger.online = false;
                }
                catch (Exception e)
                {
                    Debug.Log("act logger component not found");
                }
            }

            Player.instance.playerData.logros[2] = DateTime.Now.ToString();
            if (!GameManager.OfflineMode)
            {
                Peticiones.instance.registerPlayerPrize((LogroSist.GetComponent<LogrosGlobales>()).logros[2].nombre, Player.instance.playerData);

            }
            else
            {

                ActionLogger ac = GameObject.Find("ActionLogger").GetComponent<ActionLogger>();
                if (!GameManager.OfflineMode)
                {
                    ac.actionLogger.agregarAccion("Settings", "Offline");
                }

                ac.actionLogger.online = false;
                ac.actionLogger.agregarPeticion("prize", (LogroSist.GetComponent<LogrosGlobales>()).logros[2].nombre, Player.instance.playerData.Token, inicio.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                try
                {
                    ac.GetComponent<ActionLogger>().actionLogger.online = false;
                }
                catch (Exception e)
                {
                    Debug.Log("act logger component not found");
                }
            }

            food.SetActive(true);
            recordatorio.SetActive(false);
            audioVocals.reproducirAlt();
            act = false;
            GameObject.FindGameObjectWithTag("Bag").GetComponent<Inventory>().TestRemoveF(1);
            GameObject.FindGameObjectWithTag("Bag").GetComponent<Inventory>().TestRemoveF(1);
            GameObject.FindGameObjectWithTag("Bag").GetComponent<Inventory>().TestRemoveF(2);
            CreateStadistics();
            Destroy(cage);
            
        }
    }

    public void sendStartReq()
    {
        inicio = DateTime.Now;
        try
        {
            if (!GameManager.OfflineMode)
            {
                JObject res = Peticiones.instance.registerStartMission("Bosque-Estación 3", Player.instance.playerData, inicio.ToString("yyyy-MM-dd hh:mm:ss"));
                if (res["payload"]["GameLevelInstanceId"] != null)
                {
                    levelId = (int)res["payload"]["GameLevelInstanceId"];
                }
            }
            else
            {

                ActionLogger ac = GameObject.Find("ActionLogger").GetComponent<ActionLogger>();
                if (!GameManager.OfflineMode)
                {
                    ac.actionLogger.agregarAccion("Settings", "Offline");
                }

                ac.actionLogger.online = false;
                ac.actionLogger.agregarPeticion("start mision", "Bosque-Estación 3", Player.instance.playerData.Token, inicio.ToString("yyyy-MM-dd hh:mm:ss"), null);
                try
                {
                    ac.GetComponent<ActionLogger>().actionLogger.online = false;
                }
                catch (Exception e)
                {
                    Debug.Log("act logger component not found");
                }
            }

        }
        catch
        {
            Debug.Log("Error al registrar inico de nivel.");
        }
    }

    public void CreateStadistics(){
        StadisticsData.Stadistics tmp1 = new StadisticsData.Stadistics("mission_data");
        string name = LogroSist.GetComponent<LogrosGlobales>().misiones[2].nombre;
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
        string prize = LogroSist.GetComponent<LogrosGlobales>().logros[2].nombre;
        StadisticsData.DataPrize dat3 = new StadisticsData.DataPrize(prize);
        tmp3.data = dat3;
        string json3 = JsonConvert.SerializeObject(tmp3,Formatting.Indented);
        GameManager.instance.CallEnumerator(json3);
        GameManager.estas.lista.Add(tmp3);
    }
}
