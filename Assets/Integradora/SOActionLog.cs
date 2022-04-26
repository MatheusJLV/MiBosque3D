using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu (fileName ="New Action Log", menuName = "Action Log")]
public class SOActionLog : ScriptableObject
{
    [System.Serializable]
    public class Accion
    {
        public string fecha;
        public string nombreAccion;
        public string detalle;
        public string player;
        public Accion(string nombre, string detalle, string player)
        {
            fecha = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            nombreAccion = nombre;
            this.detalle = detalle;
            Debug.Log("Se registro un: " + nombre);
            this.player = player;
        }
        public Accion(string nombre, string detalle, PlayerData player)
        {
            fecha = System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            nombreAccion = nombre;
            this.detalle = detalle;
            this.player = player.nombre + "-" + player.UserName + "-" + player.PassWord + "-" + player.Token;
            Debug.Log("Se registro un: " + nombre);
        }

    }

    [System.Serializable]
    public class AccionList
    {
        public Accion[] acciones;
    }


    [System.Serializable]
    public class PeticionesPendientes
    {
        public string tipo;
        public string nombre;
        public string token;
        public string started;
        public string ended;
        public PeticionesPendientes(string tipo, string nombre, string token, string started, string ended)
        {
            this.tipo = tipo;
            this.nombre = nombre;
            this.token = token;
            this.started = started;
            this.ended = ended;
            Debug.Log("Se registro una peticion pendiente: " + nombre);


        }
    }

   [System.Serializable]
   public class PeticionesPendientesList
   {
        public PeticionesPendientes[] peticionesPendientes;
   }

   public PeticionesPendientesList lista2 = new PeticionesPendientesList();



   public AccionList lista = new AccionList();

    


    public List<Accion> acciones;
    public List<PeticionesPendientes> peticiones;
    [SerializeField]
    public bool jugando = false;
    public bool online = false;
    [SerializeField]
    public string locacion;
    public string player;
    public float[] tiempos;

    public void Inicializar()
    {
        if (acciones==null)
        {
            acciones = new List<Accion>();
            peticiones = new List<PeticionesPendientes>();
        }
        if (jugando)
        {
            acciones.Add(new Accion("Juego Interrumpido","Juego iniciado despues de cierre inesperado detectado en " +locacion,player));
        }
        jugando = true;

    }
    public void agregarAccion(string nombre, string detalle)
    {
        //if online
        if (false)
        {
            //send accion
        }
        else
        {
            //write accion
            acciones.Add(new Accion(nombre, detalle, player));
        }
        
    }
    public void agregarAccion(string nombre, string detalle, PlayerData player)
    {
        //if online
        if (false)
        {
            //send accion
        }
        else
        {
            //write accion
            acciones.Add(new Accion(nombre, detalle, player));
        }
        
    }
    public void agregarPeticion(string tipo, string nombre, string token, string started, string ended)
    {
        //if online
        if (false)
        {
            //send accion
        }
        else
        {
            //write accion
            Debug.Log("se agrego peticion "+nombre);
            peticiones.Add(new PeticionesPendientes(tipo, nombre, token, started, ended));
        }

    }
    public void printLog()
    {
        Debug.Log("LOG DE EVENTOS REGISTRADOS");
        int contador=1;
        foreach (Accion accion in acciones)
        {
            Debug.Log("ACCION REGISTRADA #"+contador);
            Debug.Log("Evento: " + accion.nombreAccion);
            Debug.Log("Fecha de suceso: " + accion.fecha);
            Debug.Log("Descripcion: " + accion.detalle);
            try{
                Debug.Log("Datos del jugador: " + accion.player);
            }
            catch (Exception e)
            {
                Debug.Log("Datos del jugador no registrados.");
            }
            contador++;
        }
    }
    public void printPeticiones()
    {
        Debug.Log("LOG DE Peticiones no enviadas REGISTRADAS");
        int contador = 1;
        foreach (PeticionesPendientes pet in peticiones)
        {
            Debug.Log("Peticione no enviada #" + contador);
            Debug.Log("peticion: " + pet.nombre);
            Debug.Log("tipo: " + pet.tipo);
            Debug.Log("Fecha de inicio: " + pet.started);
            Debug.Log("Fecha de fin: " + pet.ended);
            try
            {
                Debug.Log("Datos del jugador: " + pet.token);
            }
            catch (Exception e)
            {
                Debug.Log("Datos del jugador no registrados.");
            }
            contador++;
        }
    }
    public void guardar()
    {
        agregarAccion("Playtime Menu partida", "" + tiempos[0]);
        agregarAccion("Playtime Tutorial", "" + tiempos[1]);
        agregarAccion("Playtime Lobby", "" + tiempos[2]);
        agregarAccion("Playtime Mapa", "" + tiempos[3]);
        agregarAccion("Playtime Bosque e1", "" + tiempos[4]);
        agregarAccion("Playtime Bosque e2", "" + tiempos[5]);
        agregarAccion("Playtime Bosque e3", "" + tiempos[6]);
        agregarAccion("Playtime Bosque e4", "" + tiempos[7]);
        agregarAccion("Playtime Bosque e5", "" + tiempos[8]);
        agregarAccion("Playtime Bosque e6", "" + tiempos[9]);
        agregarAccion("Playtime Bosque e7", "" + tiempos[10]);

        for (int i =0; i<tiempos.Length;i++)
        {
            tiempos[i] = 0f;
        }

        string texto = "{\"acciones\":[";
        bool ban = false;
        foreach (Accion ac in acciones)
        {
            if (ban)
            {
                texto += ",";                
            }
            ban = true;
            texto += "{\"fecha\":\"" + ac.fecha + "\",\"nombreAccion\":\"" + ac.nombreAccion + "\",\"detalle\":\"" + ac.detalle + "\",\"player\":\"" + ac.player + "\"}";

        }
        texto += "]}";
        Debug.Log(texto);
        //JObject jsonResponse = JObject.Parse(texto);
        File.WriteAllText(Application.dataPath + "/Resources/LogAcciones.json", texto);
        Debug.Log("guardado con exito");
    }

    public void guardarPeticionesPendientes()
    {
        string texto = "{\"peticionesPendientes\":[";
        bool ban = false;
        foreach (PeticionesPendientes pet in peticiones)
        {
            if (ban)
            {
                texto += ",";
            }
            ban = true;
            texto += "{\"tipo\":\"" + pet.tipo + "\",\"nombre\":\"" + pet.nombre + "\",\"token\":\"" + pet.token + "\",\"started\":\"" + pet.started + "\",\"ended\":\"" + pet.ended + "\"}";

        }
        texto += "]}";
        Debug.Log(texto);
        //JObject jsonResponse = JObject.Parse(texto);
        File.WriteAllText(Application.dataPath + "/Resources/LogPeticiones.json", texto);
        Debug.Log("Peticiones - guardado con exito");
    }
    public void cargarLocal()
    {
        lista = JsonUtility.FromJson<AccionList>(Resources.Load<TextAsset>("LogAcciones").text);
        /*Debug.Log("PROBANDO LECTURA DE LOG");
        string jsonResult2 = Resources.Load<TextAsset>("LogAcciones").text;
        Debug.Log(jsonResult2);
        PreguntaObject[] preguntaList2 = JsonHelper.GetJsonArray<Accion>(jsonResult2);
        List<PreguntaObject> lista2 = new List<PreguntaObject>(preguntaList2);
        PreguntaObjectList lista_final2 = new PreguntaObjectList
        {
            preguntas = lista2
        };
        Debug.Log(lista_final2.ToString());
        Debug.Log("LECTURA DE NUEVAS PREGUNTAS CON EXITO");*/
        Debug.Log("lectura de log de acciones");
        Debug.Log(lista.acciones.ToString());
        Debug.Log(lista.acciones.Length);
        Debug.Log("lectura de log de acciones finalizada");
    }
    public void cargarLocalPeticiones()
    {
        lista2 = JsonUtility.FromJson<PeticionesPendientesList>(Resources.Load<TextAsset>("LogPeticiones").text);
        Debug.Log("lectura de log de peticiones");
        Debug.Log(lista2.peticionesPendientes.ToString());
        Debug.Log(lista2.peticionesPendientes.Length);
        Debug.Log("lectura de log de peticiones finalizada");
    }
    public void clearLog()
    {
        acciones= new List<Accion>();
    }
}


