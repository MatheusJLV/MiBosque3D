using UnityEngine;
using UnityEngine.UI;

public class CharacterQuestions : MonoBehaviour
{
    Image m_Image;
    //Set this in the Inspector
    public Sprite personaje_triste;
    public Sprite personaje_feliz;
    public Sprite personaje_normal;

    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }

    public void PersonajeTriste() //method to set our first image
    {
        m_Image.sprite = personaje_triste;
    }

    public void PersonajeFeliz() //method to set our first image
    {
        m_Image.sprite = personaje_feliz;
    }


    public void PersonajeRestart()
    {
        m_Image.sprite = personaje_normal;
    }

}