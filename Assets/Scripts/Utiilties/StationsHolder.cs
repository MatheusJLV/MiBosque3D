using UnityEngine;

public class StationsHolder : MonoBehaviour {
    public Estacion[] estaciones;

    private void Awake() {
        for (int i = 0; i < GameManager.instance.playerData.eventosEstaciones.Length; i++)
        {
            if(GameManager.instance.playerData.eventosEstaciones[i]!=null)
                estaciones[i].activos=GameManager.instance.playerData.eventosEstaciones[i];
        }
    }
}