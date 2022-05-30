using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLogger : MonoBehaviour
{
    [SerializeField]
    public SOActionLog actionLogger;

    void Start()
    {
        actionLogger.Inicializar();
        DontDestroyOnLoad(this.gameObject);
        actionLogger.cargarLocalPeticiones();
        actionLogger.cargarLocal();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            actionLogger.printPeticiones();
            actionLogger.printLog();
        }
        if (Input.GetKeyDown("g"))
        {
            actionLogger.guardarPeticionesPendientes();
            actionLogger.guardar();
        }
        if (Input.GetKeyDown("b"))
        {
            actionLogger.clearLog();
            actionLogger.clearPeticiones();
            for (int i =0; i< actionLogger.tiempos.Length; i++)
            {
                actionLogger.tiempos[i] = 0f;
            }
            
        }
        if (actionLogger.jugando)
        {
            switch (actionLogger.locacion)
            {
                case "Menu Partida":
                    actionLogger.tiempos[0] += Time.deltaTime;
                    break;
                case "Tutorial":
                    actionLogger.tiempos[1] += Time.deltaTime;
                    break;
                case "Mapa":
                    actionLogger.tiempos[2] += Time.deltaTime;
                    break;
                case "Lobby":
                    actionLogger.tiempos[3] += Time.deltaTime;
                    break;
                case "Bosque e1":
                    actionLogger.tiempos[4] += Time.deltaTime;
                    break;
                case "Bosque e2":
                    actionLogger.tiempos[5] += Time.deltaTime;
                    break;
                case "Bosque e3":
                    actionLogger.tiempos[6] += Time.deltaTime;
                    break;
                case "Bosque e4":
                    actionLogger.tiempos[7] += Time.deltaTime;
                    break;
                case "Bosque e5":
                    actionLogger.tiempos[8] += Time.deltaTime;
                    break;
                case "Bosque e6":
                    actionLogger.tiempos[9] += Time.deltaTime;
                    break;
                case "Bosque e7":
                    actionLogger.tiempos[10] += Time.deltaTime;
                    break;
                default:
                    print("Locacion no identificada");
                    break;
            }
        }

        
    }
}
