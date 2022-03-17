using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class ManejadorCalidad : MonoBehaviour
{
    public GameObject[] Estaciones;
    public GameObject WindZone;
    public GameObject Terreno;
    public GameObject SistemaPajaros;
    public GameObject FpsController;
    public int max;
    public int act;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Data");
        
        max = FpsController.GetComponent<Player>().playerData.maxStation;
        Debug.Log("Max:" + max);
        
        act = GameManager.instance.currentStation ;
        Debug.Log("Actual:" + act);

        for (int i =1; i< max; i++)
        {
            //Estaciones[i-1].GetComponent<ManejadorEstacion>().estado = true;
            Estaciones[i - 1].GetComponent<ManejadorEstacion>().desactivar();
        }
        if (act<3)
        {
            Estaciones[0].GetComponent<ManejadorEstacion>().activar();
            Estaciones[1].GetComponent<ManejadorEstacion>().activar();
            Estaciones[2].GetComponent<ManejadorEstacion>().activar();
        } else if (act>5)
        {
            Estaciones[4].GetComponent<ManejadorEstacion>().activar();
            Estaciones[5].GetComponent<ManejadorEstacion>().activar();
            Estaciones[6].GetComponent<ManejadorEstacion>().activar();
        }
        else
        {
            Estaciones[act-2].GetComponent<ManejadorEstacion>().activar();
            Estaciones[act-1].GetComponent<ManejadorEstacion>().activar();
            Estaciones[act].GetComponent<ManejadorEstacion>().activar();
        }
    }

    public void updateStation(int estacion)
    {


        if (estacion!=act)
        {
            if (estacion > 1 && estacion < 7)
            {
                if (act < estacion && estacion > 2)
                {
                    Estaciones[estacion - 3].GetComponent<ManejadorEstacion>().desactivar();
                    Estaciones[estacion - 2].GetComponent<ManejadorEstacion>().completar();
                    Estaciones[estacion].GetComponent<ManejadorEstacion>().activar();
                }
                else if (act > estacion && estacion < 6)
                {
                    /*if (estacion + 1 < max)
                    {
                        Estaciones[estacion + 1].GetComponent<ManejadorEstacion>().dormir();
                    }
                    else*/
                    {
                        Estaciones[estacion + 1].GetComponent<ManejadorEstacion>().dormir();
                    }
                    Estaciones[estacion - 2].GetComponent<ManejadorEstacion>().activar();
                }
            }
        }

        act = estacion;
        max = Math.Max(act,max);


    }

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            prueba();
        }
    }

    void prueba()
    {
        Debug.Log("Probando manejador");
        Terreno.GetComponent<Terrain>().detailObjectDensity = 0;
        WindZone.SetActive(false);
    }*/


    public void minima()
    {
        Debug.Log("Minimizando recursos");
        Terrain terreno = Terreno.GetComponent<Terrain>();
        terreno.drawInstanced = true;
        terreno.heightmapPixelError  = 5;
        terreno.basemapDistance = 13;
        terreno.shadowCastingMode  = ShadowCastingMode.Off;
        terreno.detailObjectDensity = 0.02f;
        terreno.detailObjectDistance = 125;
        terreno.treeDistance  = 150;
        terreno.treeBillboardDistance  = 30;
        terreno.treeCrossFadeLength  = 130;
        terreno.treeMaximumFullLODCount   = 15;
        SistemaPajaros.SetActive(false);
        WindZone.SetActive(false);
    }
    public void media()
    {
        Debug.Log("reestableciendo recursos originales");
        Terrain terreno = Terreno.GetComponent<Terrain>();
        terreno.drawInstanced = false;
        terreno.heightmapPixelError = 5;
        terreno.basemapDistance = 1000;
        terreno.shadowCastingMode = ShadowCastingMode.TwoSided;
        terreno.detailObjectDensity = 0.086f;
        terreno.detailObjectDistance = 134;
        terreno.treeDistance = 1300;
        terreno.treeBillboardDistance = 40;
        terreno.treeCrossFadeLength = 60.6f;
        terreno.treeMaximumFullLODCount = 63;
        WindZone.SetActive(true);
        SistemaPajaros.SetActive(true);
    }
    public void maxima()
    {
        Debug.Log("Maximizando recursos");
        Terrain terreno = Terreno.GetComponent<Terrain>();
        terreno.drawInstanced = false;
        terreno.heightmapPixelError  = 200;
        terreno.basemapDistance = 2000;
        terreno.shadowCastingMode  = ShadowCastingMode.TwoSided;
        terreno.detailObjectDensity = 1;
        terreno.detailObjectDistance = 250;
        terreno.treeDistance  = 5000;
        terreno.treeBillboardDistance  = 2000;
        terreno.treeCrossFadeLength  = 2;
        terreno.treeMaximumFullLODCount   = 10000;
        WindZone.SetActive(true);
        SistemaPajaros.SetActive(true);
    }
    
}
