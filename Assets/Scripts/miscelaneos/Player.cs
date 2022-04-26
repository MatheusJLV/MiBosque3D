using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{

    public PlayerData playerData;
    public static Player instance;
    public bool isDialogOpened;
    public Text numHojasT;
    public Text nDesafiosCompletadosT;
    public Text nEstacionT;
    private bool begin=false;

    private void Start()
    {
        //playerData.numHojas = 0;
        //playerData.numEstacion = 1;
        //playerData.maxStation = 1;
        //playerData.numDesafiosCompletados = 0;
        instance = this;
        isDialogOpened = false;
        //StartCoroutine(GameManager.getAuthToken());
    }

    private void Update()
    {
        if (MenuPausa.IsPaused)
        {
            begin = true;
        }
        else
        {
            if (!MenuPausa.IsPaused && begin)
            {
                GetComponent<FirstPersonController>().enabled = false;
            }
            begin = false;

        }
    }

    public void SetPlayerData(PlayerData playerData)
    {
        this.playerData = playerData;
    }
    public void gainEXP(int exp)
    {
        playerData.earnEXP(exp);
    }

    public void DesafioCompletado()
    {
        playerData.numDesafiosCompletados++;
        ActualizarUI();
    }

    public void PreguntasCorrectas()
    {
        playerData.numHojas++;
        ActualizarUI();
    }

    public void EstacionActual(int id)
    {
        playerData.numEstacion = id;
        ActualizarUI();
    }

    public void ActualizarUI()
    {
        nEstacionT.text = playerData.numEstacion.ToString();
        numHojasT.text = playerData.numHojas.ToString();
        nDesafiosCompletadosT.text = playerData.numDesafiosCompletados.ToString();
    }
    public void regLogro(int logro, string fechap)
    {
        playerData.logros[logro] = fechap;
    }
    public void regMision(int mision)
    {
        playerData.misiones[mision] = true;
    }
    /*
    IEnumerator debugging()
    {

        while (true)
        {
            print("Numero de hojas " + nHojas);
            print("Numero de estacioN " + nEstacion);
            print("Numero de desafios completados " + nDesafiosCompletados);
            print("Maxima estacion " + maxStationPlayed);
            print("La curren station del gamemanager es: " + GameManager.instance.currentStation);

            yield return new WaitForSeconds(4f);
        }
    }
*/
}

[System.Serializable]
public class tokenClass
{
    public string token { get; set; }

}

public class UserTest
{
    public string username;
    public string password;

    public UserTest(string user, string pass)
    {
        this.username = user;
        this.password = pass;
    }
}


