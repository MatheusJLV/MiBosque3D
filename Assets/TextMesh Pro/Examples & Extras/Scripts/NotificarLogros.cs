using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notificacion
{
    public string titulo;
    public string descripcion;
    public GameObject imagen;
    public Notificacion(string titulop, string descripcionp, GameObject imagenp)
    {
        titulo = titulop;
        descripcion = descripcionp;
        imagen = imagenp;
    }

}

public class NotificarLogros : MonoBehaviour
{
    //Notificacion a mostrar
    public GameObject notifPanel; //objeto donde se contendra notificacion
    public GameObject descripcionLogro;
    public GameObject tituloLogro;
    public AudioSource sonido;
    public bool activo; //mostrando logro en progreso
    public List<Notificacion> logros;
    public Notificacion actual;
    public GameObject CanvasJoysticks;
    // Start is called before the first frame update
    void Start()
    {
        logros = new List<Notificacion>();
        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activo)
        {
            if (!(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
            {
                if (logros.Count > 0)
                {
                    StartCoroutine(TriggerLogro(actual));
                }

            }
                
            

        }
    }
    public void Encolar(string titulop, string descripcionp, GameObject imagenp)
    {

        actual = new Notificacion(titulop, descripcionp, imagenp);
        logros.Add(actual);
    }
    public void cerrar()
    {
        //MenuPausa.instance.Reanudar();
#if UNITY_ANDROID || UNITY_IOS
        CanvasJoysticks.SetActive(true);
#endif


        tituloLogro.GetComponent<Text>().text = "";
        descripcionLogro.GetComponent<Text>().text = "";
        actual.imagen.SetActive(false);
        notifPanel.SetActive(false);
        logros.RemoveAt(0);
        activo = false;


        if (logros.Count == 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator TriggerLogro(Notificacion logro)
    {
        //MenuPausa.instance.Pausar();
#if UNITY_ANDROID || UNITY_IOS
        CanvasJoysticks.SetActive(false);
#endif

        Debug.Log("**********************se activa notif ");
        activo = true;
        notifPanel.SetActive(true);
        logro.imagen.SetActive(true);
        tituloLogro.GetComponent<Text>().text = logros[0].titulo;
        descripcionLogro.GetComponent<Text>().text = logros[0].descripcion;
        yield return new WaitForSeconds(5);
        cerrar();

    }
}
    
