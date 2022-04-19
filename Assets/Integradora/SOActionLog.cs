using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName ="New Action Log", menuName = "Action Log")]
public class SOActionLog : ScriptableObject
{
    public List<Accion> acciones;
    [SerializeField]
    public bool jugando = false;
    [SerializeField]
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
        }
        if (jugando)
        {
            acciones.Add(new Accion("Juego Interrumpido","Juego iniciado despues de cierre inesperado detectado en " +locacion,player));
        }
        jugando = true;
    }
    public void agregarAccion(string nombre, string detalle)
    {
        acciones.Add(new Accion(nombre,detalle,player));
    }
    public void agregarAccion(string nombre, string detalle, PlayerData player)
    {
        acciones.Add(new Accion(nombre, detalle, player));
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
    public void clearLog()
    {
        acciones= new List<Accion>();
    }
}


public class Accion
{
    public string fecha;
    public string nombreAccion;
    public string detalle;
    public string player;
    public Accion(string nombre, string detalle,string player)
    {
        fecha= System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
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
        Debug.Log("Se registro un: " +nombre);
    }
    
}
