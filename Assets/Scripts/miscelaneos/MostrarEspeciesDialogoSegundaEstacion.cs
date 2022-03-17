using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarEspeciesDialogoSegundaEstacion : DialogueTrigger
{


    public Image m_Image;
    //Set this in the Inspector
    public Sprite especie1;


    public Image m_Image2;
    //Set this in the Inspector
    public Sprite especie2;

    public Image m_Image3;
    //Set this in the Inspector
    public Sprite especie3;

    /*void Start()
    {
        SetEspecies();
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
        m_Image2 = GetComponent<Image>();
        m_Image3 = GetComponent<Image>();

    }*/

    public override void TriggerDialogue()
    {
        SetEspecies();
        base.TriggerDialogue();


    }

    public void SetEspecies() //method to set our first image
    {

        m_Image.sprite = especie1;
        m_Image.gameObject.SetActive(true);

        m_Image2.sprite = especie2;
        m_Image2.gameObject.SetActive(true);

        m_Image3.sprite = especie3;
        m_Image3.gameObject.SetActive(true);

    }

    public void OcultarEspecies() //method to set our first image
    {

        
        m_Image.gameObject.SetActive(false);

        
        m_Image2.gameObject.SetActive(false);

        
        m_Image3.gameObject.SetActive(false);

    }



    /*Es hora de que empieces a llenar un poco m㳠ese libro.

Identifica 3 especies distintas en el bosque al interactuar con ellos.

    RECUERDA: Para interactuar con los arboles y animalitos del bosque, coloca el PUNTO DE MRA donde desees y haz CLICK sobre ellas

 */


}
