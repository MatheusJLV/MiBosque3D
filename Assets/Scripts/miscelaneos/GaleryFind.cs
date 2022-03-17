using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class GaleryFind : MonoBehaviour
{

    
    public TextMeshProUGUI titulo;
    public TextMeshProUGUI cuerpo;
    public Texture[] imagenes;
    public int imagenActual = 0;
    public RawImage imagen;
    public string[] pistas;


    private Arbol tree = null;
    public bool visible;

    void Update()
    {
        if (visible)
        {
            CargarInfo(imagenActual);
            visible = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.A))
        {
            CargarImagen(1);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D))
        {
            CargarImagen(-1);
        }
    }

    public void CargarImagen(int num)
    {
        imagenActual += num;
        if (imagenActual >= 3)
        {
            imagenActual = 0;
        }
        else if (imagenActual < 0)
        {
            imagenActual = 0;
        }

        cuerpo.text = pistas[imagenActual];


        LoadImage(imagenActual);
    }

    public void CargarInfo(int num)
    {

        
        titulo.text = pistas[num];
        CargarImagen(0);

    }


    public void LoadImage(int num)
    {
        imagen.texture = imagenes[num];


        /*
        UnityWebRequest w = UnityWebRequestTexture.GetTexture(image_url + tree.Id + "/gallery/" + id + "/");
        w.SetRequestHeader("Authorization", GameManager.authToken);    //Se agrego linea de token de autorizacion
        Debug.Log("URL de la imagen: " + image_url + treeID + "/gallery/" + id + "/");
        yield return w.SendWebRequest();

        if (w.responseCode.Equals(401))
        {
            StartCoroutine(GameManager.getAuthToken());
            w.SetRequestHeader("Authorization", GameManager.authToken);
            yield return w.SendWebRequest();
        }
        if (w.isNetworkError || w.isHttpError)
        {
            Debug.Log(w.error);
        }
        else
        {
            imagen.texture = ((DownloadHandlerTexture)w.downloadHandler).texture;

        }*/
    }






    //La siguiente linea corresponde a llenar el libro de especies del jugador
    /*public IEnumerator registrarEspecieEnLibro()
    {
        Debug.Log("Dentro del script Galery se llamo a la funcion registrarEspecieEnLibro.");
        yield return new WaitForSeconds(3f);
        BookPages.instance.nombres.Add(tree.Name);
        BookPages.instance.descripciones.Add(cuerpo.text);
        if(imagen.texture!= null)
            BookPages.instance.imagenes.Add(imagen.texture);
    }*/
}
