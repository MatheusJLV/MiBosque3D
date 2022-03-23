using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public TextMeshProUGUI nombre;
    public TextMeshProUGUI genero;
    public TextMeshProUGUI edad;
    public TextMeshProUGUI nivel;
    public TextMeshProUGUI experiencia;
    public TextMeshProUGUI unidadEdu;
    public Sprite[] sprites;
    public Image img;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {
        nombre.text = player.playerData.nombre;
        genero.text = player.playerData.personajeSeleccionado;
        unidadEdu.text = player.playerData.unidadEducativa;
        Debug.Log(player.playerData.personajeSeleccionado);
        /*if (player.playerData.personajeSeleccionado.Equals("NIÑO 2-07")) {
            Debug.Log(1);
            img.sprite = sprites[0];
        }
        else if (player.playerData.personajeSeleccionado.Equals("ninabien")) {
            Debug.Log(2);
            img.sprite = sprites[1];
    }
        else if (player.playerData.personajeSeleccionado.Equals("NIÑO 3-08"))
        {
            Debug.Log(3);
            img.sprite = sprites[2];
        }
        else if (player.playerData.personajeSeleccionado.Equals("NIÑA 2-02")) {
            Debug.Log(4);
            img.sprite = sprites[3];
        }*/

edad.text += player.playerData.edad + " años";

        if (player.playerData.experiencia == 0)
        {
            experiencia.text = "-";
            nivel.text = "0";
        }
        else if (player.playerData.experiencia == 80)
        {
            experiencia.text = "Experiencia: Max exp";
            nivel.text = "Nivel: 7";
        }
        else
        {
            experiencia.text = "" + player.playerData.experiencia + " / " + player.playerData.limites[player.playerData.nivel] + " ";
            nivel.text = "" + player.playerData.nivel;
        }
        string personajeValid = player.playerData.personajeSeleccionado;
        if (personajeValid.Equals("NIÑO 2-07"))
        {
            personajeValid = "Artboard 8";
        }
        else if (personajeValid.Equals("ninabien"))
        {
            personajeValid = "jugador 4 cabeza";
        }
        else if (personajeValid.Equals("NIÑO 3-08"))
        {
            personajeValid = "Artboard 10";
        }
        else if (personajeValid.Equals("NIÑA 2-02"))
        {
            personajeValid = "Artboard 3";
        }

        img.sprite = Resources.Load<Sprite>("RECURSOS GRAFICOS DEL JUEGO 08-2020/PERSONAJES NIÑOS Y NIÑAS/" + personajeValid);
        //experiencia.text += player.playerData.experiencia;
    }

    public void UpdateProfile()
    {
        if (player.playerData.experiencia == 80)
        {
            experiencia.text = "Max exp";
            nivel.text = "7";
        }
        else
        {
            nivel.text = "" + player.playerData.nivel;
            experiencia.text = "" + player.playerData.experiencia + " / " + player.playerData.limites[player.playerData.nivel] + "";
        }



    }

}