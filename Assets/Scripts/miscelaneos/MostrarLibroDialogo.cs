using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarLibroDialogo : DialogueTrigger
{
    public Image m_Image;
    //Set this in the Inspector
    public Sprite libro;
    

    public override void TriggerDialogue()
    {
        SetLibro();
        base.TriggerDialogue();


    }

    /*
    void Start()
    {
        SetLibro();
        //Fetch the Image from the GameObject
        //m_Image = GetComponent<Image>();
        
    }*/

    public void SetLibro() //method to set our first image
    {
        m_Image.sprite = libro;
        m_Image.gameObject.SetActive(true);
    }

    public void DisableImage() {

        m_Image.gameObject.SetActive(false);
    }
    
}

