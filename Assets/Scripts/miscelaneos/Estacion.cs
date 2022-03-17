using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estacion : MonoBehaviour
{

    public int ID;

    public GameObject[] eventosActDesc;
    public GameObject spawn;
	[Header("MARCAR TODO COMO TRUE EN EL INSPECTOR")]
    public bool[] activos;
    private Dictionary<string, int> dicEvntIndex = new Dictionary<string, int>();


    private void Start()
    {
        for (int i = 0; i < eventosActDesc.Length; i++)
        {
			dicEvntIndex.Add(eventosActDesc[i].name, i);
			eventosActDesc[i].SetActive(activos[i]);
        }
    }

    public void DesactivarEvento(GameObject GOEvento){
        int ind=0;
        if (dicEvntIndex.TryGetValue(GOEvento.name,out ind)){
            eventosActDesc[ind].SetActive(false);
            Destroy(eventosActDesc[ind]);
            activos[ind]=false;
        }
    }
}


