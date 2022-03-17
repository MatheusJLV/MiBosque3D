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
        nombre.text += player.playerData.nombre;
        genero.text += player.playerData.personajeSeleccionado;
        unidadEdu.text += player.playerData.unidadEducativa;
        if (player.playerData.personajeSeleccionado.Equals("Niño"))
            img.sprite = sprites[0];
        else
            img.sprite = sprites[1];
        edad.text += player.playerData.edad;

        if (player.playerData.experiencia == 0)
        {
            experiencia.text = "Experiencia: 0/5 exp";
            nivel.text = "Nivel: 1";
        }
        else if (player.playerData.experiencia == 80)
        {
            experiencia.text = "Experiencia: Max exp";
            nivel.text = "Nivel: 7";
        }
        else
        {
            experiencia.text = "Experiencia: " + player.playerData.experiencia + " / " + player.playerData.limites[player.playerData.nivel] + " exp";
            nivel.text = "Nivel: " + player.playerData.nivel;
        }
        img.sprite = Resources.Load<Sprite>("RECURSOS GRAFICOS DEL JUEGO 08-2020/PERSONAJES NIÑOS Y NIÑAS/" + player.playerData.personajeSeleccionado);
        //experiencia.text += player.playerData.experiencia;
    }

    public void UpdateProfile()
    {
        if (player.playerData.experiencia == 80)
        {
            experiencia.text = "Experiencia: Max exp";
            nivel.text = "Nivel: 7";
        }
        else
        {
            nivel.text = "Nivel: " + player.playerData.nivel;
            experiencia.text = "Experiencia: " + player.playerData.experiencia + " / " + player.playerData.limites[player.playerData.nivel] + " exp";
        }



    }

}