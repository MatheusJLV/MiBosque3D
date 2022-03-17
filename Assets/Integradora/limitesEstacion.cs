using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class limitesEstacion : MonoBehaviour
{
    // Start is called before the first frame update
    public int station;
    /*
             * SE AGREGO PARA INTEGRADORA
             */
    public GameObject performanceManager;


    void OnTriggerEnter(Collider obj)
    {
#if UNITY_ANDROID || UNITY_IOS
        GameObject.Find("Estacion").GetComponent<RectTransform>().localPosition = new Vector3(0f,200f,0f);
#endif
        if (obj.gameObject.tag == "Player")
        {
            Debug.Log("Acabo de pasar por un gameobj con wall trigger en estacion: " + station);
            //El numero de la estacion
            /*
             * SE AGREGO PARA INTEGRADORA
             */
            performanceManager.GetComponent<ManejadorCalidad>().updateStation(station);
        }
    }

}