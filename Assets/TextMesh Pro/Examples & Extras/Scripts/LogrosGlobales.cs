using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

//pendiente ver consumo y rendimineto. sugeriria activar y desactivar componente segun el uso 
//trigger activa, si no hay pendientes el sistema se auto desactiva

public abstract class Logro
{
    public string nombre;
    public string descripcion;
    public int estado;
    public GameObject imagen;
    public string fecha;

    public abstract bool Progreso();
    public abstract bool ProgresoPrev(string fecha);

}

public class Mision
{
    public string nombre;
    //Oculto, Bloqueado, Incompleto, Completo
    public string estado;
    public string descripcion;
    public List<string> requisitosBlock = new List<string>();
    public List<string> requisitos = new List<string>();
    public List<string> requisitosHechos = new List<string>();
    public List<int> estacion = new List<int>();

    public Mision(string nombrep, string estadop, List<string> req1, List<string> req2, List<string> req3, List<int> estacionp, String descripcionp)
    {
        nombre = nombrep;
        estado = estadop;
        requisitosBlock = req1;
        requisitos = req2;
        requisitosHechos = req3;
        estacion = estacionp;
        descripcion = descripcionp;
    }

    public bool Progreso(string requisito)
    {
        //Debug.Log("**********************se recibe 2 el nombre " + requisito);
        if (estado != "Completa")
        {
            if (estado == "Bloqueada")
            {
                //Debug.Log("**********************se remueve el bloqueo " + requisito);

                requisitosBlock.Remove(requisito);
                if (requisitosBlock.Count == 0)
                {
                    estado = "Incompleta";
                }
            }
            else
            {
                //Debug.Log("**********************se remueve el requisito " + requisito);

                if (requisitos.Contains(requisito))
                {
                    requisitosHechos.Add(requisito);
                }

                requisitos.Remove(requisito);
                if (requisitos.Count == 0)
                {
                    estado = "Completa";
                    return true;
                }
            }

        }
        return false;
    }

}

public class LogroUnico : Logro
{
    public LogroUnico(string nombreP, string descripcionP, GameObject imagenP)
    {
        nombre = nombreP;
        descripcion = descripcionP;
        estado = 0;
        imagen = imagenP;
        fecha = "";
    }
    public override bool Progreso()
    {
        if (estado == 1)
        {
            return false;
        }
        estado += 1;
        
        if (nombre != "Completo 100%")
        {
            //LogrosGlobales.Completo100.Progreso();
        }

        fecha = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        return true;
    }
    public override bool ProgresoPrev(string fechap)
    {
        estado += 1;
        if (nombre != "Completo 100%")

            fecha = fechap;

        return true;
    }

}

public class LogroRepetible : Logro
{
    public int contadorInicial;
    public int iteracionActual;
    public int iteracionMax;


    public LogroRepetible(string nombreP, string descripcionP, int contadorInicialP, int iteracionMaxP, GameObject imagenP)
    {
        nombre = nombreP;
        descripcion = descripcionP;
        estado = contadorInicialP;
        contadorInicial = contadorInicialP;
        iteracionActual = 0;
        iteracionMax = iteracionMaxP;
        imagen = imagenP;
        fecha = "";
    }

    public override bool Progreso()
    {
        if (estado < 1)
        {
            //Debug.Log(nombre + " en estado " + estado);
            estado += 1;
            //Debug.Log(nombre + " Progreso + 1 " + estado);
            if (estado == 1)
            {
                iteracionActual += 1;
                if (iteracionActual < iteracionMax)
                {
                    estado = contadorInicial;
                    //Debug.Log("reset de estado");
                }
                fecha = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
                LogrosGlobales.Completo100.Progreso();
                return true;
            }
        }


        return false;
    }
    public override bool ProgresoPrev(string fechap)
    {
        estado = 1;
        fecha = fechap;
        return true;

    }

}

public class LogrosGlobales : MonoBehaviour
{
    public float countdown = 0;
    public GameObject mochilaGo;

    public GameObject playerCtrl;

    public GameObject PanellistaLogros;
    public GameObject PanellistaMedallas;
    public GameObject medallas;
    public GameObject medallasdetalle;
    public GameObject medallasdetalleTitulo;
    public GameObject medallasdetalleFecha;
    public GameObject medallasdetalleDesc;
    public GameObject medallasdetalleImagen;
    public GameObject misionesLista;
    public GameObject misionesdetalle;
    public GameObject misionesdetalleTitulo;
    public GameObject misionesdetalleEstado;
    public GameObject misionesEstacion;
    public GameObject misionesRequisitos;

    public GameObject refLock;
    public GameObject refCheck;

    public GameObject puntero;

    public List<GameObject> imagenesEstados = new List<GameObject>();

    public List<GameObject> listaMedallas = new List<GameObject>();
    public List<GameObject> SlothsMedallas = new List<GameObject>();

    public List<GameObject> listaSloths = new List<GameObject>();


    public int slothPage;

    public GameObject titulomisiones;

    public bool tempResult;


    public static Logro Completo100;
    public GameObject notificaciones;

    public List<Logro> logros = new List<Logro>();
    public List<Mision> misiones = new List<Mision>();

    //logros individuales tienen nombre y descripcion, 
    //estado negativo faltan requisitos, 0 incompleto, 1 completo pero no mostrado, 2 completo y mostrado

    //Logro encontrar 3 especies
    //deberia ser obligatorio para seguir, para que el niño vaya aprendiendo del tutorial
    public GameObject imageLogro1;

    //Logro de salvar conejo
    //NO OBLIGATORIO (sirve como parametro de perseverancia del niño, cuanto tardó y si renunció, inlcuso si pasó por alto el conejo)
    public GameObject imageLogro2;

    //Logros de alimentar pajaro
    //NO OBLIGATORIO
    public GameObject imageLogro3;

    //Logro de apagar fogata
    //No obligatorio
    public GameObject imageLogro4;

    //Logro de reciclaje
    //No obligatorio
    public GameObject imageLogro5;

    //Logro sembrar 2 arboles
    //NO OBLIGATORIO
    public GameObject imageLogro6;

    //Logro de nivel
    //state debería variar solo de 0 a 1 ya que se pueden subir varios niveles
    //definir exp
    public GameObject imageNivel;

    //Logro de animales vistos
    //states 0, 1, 2 con doble iteración para "haber visto suficientes animales para haber visto todo"
    // segunda iteración vio absolutamente todo
    public GameObject imageFauna;

    //Logro de plantas vistas
    //states 0, 1, 2 con doble iteración para "haber visto suficientes plantas para haber visto todo"
    // segunda iteración vio absolutamente todo
    public GameObject imageFlora;

    //Logro de EJuego terminado
    public GameObject imageCompletado;

    //Logro de Estaciones completas correctamente
    //Settear el numero negativo para que sumados los requisitos den 1
    public GameObject imagePerfecto;

    //checks
    public List<GameObject> checks = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        tempResult = false;
        //estados Bloqueado Completa Incompleta Oculto

        List<string> requisitosBlo;
        List<string> requisitosComp;
        List<string> requisitosHechos;
        List<int> reqEstaciones;
        Mision mision;

        /*
         * aqui tambien va lo de los checks
         */
        if (playerCtrl.GetComponent<Player>().playerData.misiones[0])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Encuentra las especies", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Muestra iniciativa buscando las especies solicitadas" +
                     " al iniciar.");
            misiones.Add(mision);
            checks[0].SetActive(false);
            checks[1].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { "Iguana", "Ardilla de Guayaquil", "Pechiche" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 1, 2 };
            mision = new Mision("Encuentra las especies", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Muestra iniciativa buscando las especies solicitadas" +
                     " al iniciar.");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }

        if (playerCtrl.GetComponent<Player>().playerData.misiones[1])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Salva al conejo", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Protege al conejo de los depredadores devolviéndolo a su hogar.");
            misiones.Add(mision);
            checks[2].SetActive(false);
            checks[3].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "Devolver el conejo a su madriguera" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 3 };

            mision = new Mision("Salva al conejo", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Protege al conejo de los depredadores devolviéndolo a su hogar.");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }


        if (playerCtrl.GetComponent<Player>().playerData.misiones[2])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Ayuda al gavilán", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Encuentra comida para el Gavilán herido guiándote por el sonido" +
                           " de la naturaleza");
            misiones.Add(mision);
            checks[4].SetActive(false);
            checks[5].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "Alimentar al Gavilan" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 4 };

            mision = new Mision("Ayuda al gavilán", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Encuentra comida para el Gavilán herido guiándote por el sonido" +
                " de la naturaleza");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }

        if (playerCtrl.GetComponent<Player>().playerData.misiones[3])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Evita el Incendio", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Salva al bosque de un potencial incendio forestal.");
            misiones.Add(mision);
            checks[6].SetActive(false);
            checks[7].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "Apagar la fogata" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 5 };

            mision = new Mision("Evita el Incendio", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Salva al bosque de un potencial incendio forestal.");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }

        if (playerCtrl.GetComponent<Player>().playerData.misiones[4])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Recicla", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Recicla la basura abandonada por otros visitantes.");
            misiones.Add(mision);
            checks[8].SetActive(false);
            checks[9].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "reciclar objetos encontrados" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 6 };

            mision = new Mision("Recicla", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Recicla la basura abandonada por otros visitantes.");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }

        if (playerCtrl.GetComponent<Player>().playerData.misiones[5])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Planta las semillas", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Planta las semillas encontradas en tu aventura.");
            misiones.Add(mision);
            checks[10].SetActive(false);
            checks[11].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "Semilla1", "Semilla2" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 3 };

            mision = new Mision("Planta las semillas", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "Planta las semillas encontradas en tu aventura.");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);

        }

        if (playerCtrl.GetComponent<Player>().playerData.misiones[6])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Amante de la fauna", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "¡¡¡Encuentra todos los animales del bosque!!!");
            misiones.Add(mision);
            checks[12].SetActive(false);
            checks[13].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "Ardilla de Guayaquil", "Iguana", "Pinzón Sabanero", "Tangara Azul y Gris", "Tirano Tropical", "Venado Cola Blanca", "Oso Perezoso", "Zorra Pampera" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 6 };

            mision = new Mision("Amante de la fauna", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "¡¡¡Encuentra todos los animales del bosque!!!");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }

        if (playerCtrl.GetComponent<Player>().playerData.misiones[7])
        {
            requisitosBlo = new List<string>() { };
            requisitosComp = new List<string>() { };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { };
            mision = new Mision("Amante de la flora", "Completa", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "¡¡¡Encuentra a todos las plantas del bosque!!!");
            misiones.Add(mision);
            checks[14].SetActive(false);
            checks[15].SetActive(true);
        }
        else
        {
            requisitosBlo = new List<string>();
            requisitosComp = new List<string>() { "Pechiche",  "Bototillo", "Fernan Sánchez", "Ceibo", "Laurel De Judea", "Jacaranda" };
            requisitosHechos = new List<string>() { };
            reqEstaciones = new List<int>() { 3 };

            mision = new Mision("Amante de la flora", "Incompleta", requisitosBlo, requisitosComp, requisitosHechos, reqEstaciones, "¡¡¡Encuentra a todos las plantas del bosque!!!");
            misiones.Add(mision);
            //Debug.Log(mision.nombre + " " + mision.estado);
        }


        slothPage = 0;

        Logro Logro = new LogroUnico("Guardabosque Explorador", "Has encontrado las especies solicitadas", imageLogro1);
        logros.Add(Logro);
        Debug.Log(Logro.descripcion);
        if (playerCtrl.GetComponent<Player>().playerData.logros[0] != "")
        { ProgresarLogro(0, playerCtrl.GetComponent<Player>().playerData.logros[0]); }
        Logro = new LogroUnico("Guardabosque Veloz", "Has salvado al conejo devolviéndolo a su madriguera", imageLogro2);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[1] != "")
        { ProgresarLogro(1, playerCtrl.GetComponent<Player>().playerData.logros[1]); }
        //Debug.Log(Logro.descripcion);
        Logro = new LogroUnico("Guardabosque Gourmet", "Has ayudado a conseguir alimento", imageLogro3);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[2] != "")
        { ProgresarLogro(2, playerCtrl.GetComponent<Player>().playerData.logros[2]); }
        //Debug.Log(Logro.descripcion);
        Logro = new LogroUnico("Guardabosque Bombero", "Has evitado un incendio", imageLogro4);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[3] != "")
        { ProgresarLogro(3, playerCtrl.GetComponent<Player>().playerData.logros[3]); }
        //Debug.Log(Logro.descripcion);
        Logro = new LogroUnico("Guardabosque Ecologista", "Has reciclado basura encontrada", imageLogro5);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[4] != "")
        { ProgresarLogro(4, playerCtrl.GetComponent<Player>().playerData.logros[4]); }
        //Debug.Log(Logro.descripcion);
        Logro = new LogroUnico("Guardabosque herbolario", "Has plantado las semillas encontradas", imageLogro6);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[5] != "")
        { ProgresarLogro(5, playerCtrl.GetComponent<Player>().playerData.logros[5]); }
        //Debug.Log(Logro.descripcion);



        Logro = new LogroRepetible("Guardian de la Fauna", "Conociste los animales del Bosque", -7, 1, imageFauna);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[6] != "")
        { ProgresarLogro(6, playerCtrl.GetComponent<Player>().playerData.logros[6]); }
        //Debug.Log(Logro.descripcion);
        Logro = new LogroRepetible("Guardian de la Flora", "Conociste las plantas del Bosque", -4, 1, imageFlora);
        logros.Add(Logro);
        if (playerCtrl.GetComponent<Player>().playerData.logros[7] != "")
        { ProgresarLogro(7, playerCtrl.GetComponent<Player>().playerData.logros[7]); }
        //Debug.Log(Logro.descripcion);
        Logro = new LogroUnico("Juego terminado", "Terminaste el juego ", imageCompletado);
        logros.Add(Logro);
        /*if (playerCtrl.GetComponent<Player>().playerData.logros[8])
        { ProgresarLogro(8, "antes"); }*/
        //Debug.Log(Logro.descripcion);
        Completo100 = new LogroRepetible("Completo 100%", "¡¡¡Completaste todo!!! ", -13, 1, imagePerfecto);
        logros.Add(Completo100);
        //Debug.Log(Logro.descripcion);
        //Logro = new LogroRepetible("Lvl Up", "Subiste a nivel ", -1, 10, imageNivel);
        //logros.Add(Logro);
        //Debug.Log(Logro.descripcion);
        Debug.Log(logros.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
        /*
        if (Input.GetKeyUp(KeyCode.N))
        {

            PanellistaLogros.SetActive(true);
            titulomisiones.SetActive(true);
            for (int i = 0; i < 6; i++)
            {
                if ((i + 4 * slothPage) < misiones.Count)
                {
                    if (misiones[i + 4 * slothPage].estado == "Oculto")
                    {
                        listaSloths[i].GetComponent<Text>().text = "???????????????????????";
                    }
                    else
                    {
                        listaSloths[i].GetComponent<Text>().text = misiones[i + 4 * slothPage].nombre;
                    }

                }


            }
        }*/
        /*
        if (Input.GetKeyUp(KeyCode.B))
        {
            PanellistaMedallas.SetActive(true);
            for (int i = 0; i < 8; i++)
            {
                if (logros[i].estado == 1)
                {
                    listaMedallas[i].GetComponent<RawImage>().color = new Color(255, 255, 255);
                }
            }
        }*/

    }
    public void abrirMedallas()
    {
        PanellistaMedallas.SetActive(true);
        mochilaGo.SetActive(false);
        puntero.SetActive(false);
        for (int i = 0; i < 8; i++)
        {
            if (logros[i].estado == 1)
            {
                listaMedallas[i].GetComponent<RawImage>().color = new Color(255, 255, 255);
                SlothsMedallas[i].GetComponent<RawImage>().color = new Color(255, 255, 0);
            }
        }
    }
    public void abrirMisiones()
    {
        PanellistaLogros.SetActive(true);
        titulomisiones.SetActive(true);
        mochilaGo.SetActive(false);
        for (int i = 0; i < 8; i++)
        {
            if ((i + 4 * slothPage) < misiones.Count)
            {
                if (misiones[i + 4 * slothPage].estado == "Oculta")
                {
                    listaSloths[i].GetComponent<Text>().text = "???????????????????????";
                }
                else
                {
                    listaSloths[i].GetComponent<Text>().text = misiones[i + 4 * slothPage].nombre;
                    if (misiones[i + 4 * slothPage].estado == "Bloqueada")
                    {
                        imagenesEstados[i].GetComponent<Image>().sprite = refLock.GetComponent<Image>().sprite;
                    }
                    else if (misiones[i + 4 * slothPage].estado == "Completa")
                    {
                        imagenesEstados[i].GetComponent<Image>().sprite = refCheck.GetComponent<Image>().sprite;
                    }
                }

            }


        }
    }

    public bool ProgresarLogro(int numeroLogro)
    {
        //Debug.Log("**********************logros:" + logros.Count);
        tempResult = logros[numeroLogro].Progreso();
        //Debug.Log("**********************en progresar logro inicio es " + tempResult);
        if (tempResult)
        {
            notificaciones.SetActive(true);
            countdown = 4;
            notificaciones.GetComponent<NotificarLogros>().Encolar(logros[numeroLogro].nombre, logros[numeroLogro].descripcion, logros[numeroLogro].imagen);
        }
        //Debug.Log("**********************en progresar envia " + tempResult);
        if (tempResult)
        {
            //Debug.Log("**********************se progresa logro " + numeroLogro);
            playerCtrl.GetComponent<Player>().regLogro(numeroLogro, DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
        }
        return tempResult;

    }

    public bool ProgresarLogro(int numeroLogro, string fechap)
    {
        tempResult = logros[numeroLogro].ProgresoPrev(fechap);

        return tempResult;

    }

    public void ProgresarMision(int numeromision, string cumplido)
    {
        // Debug.Log("**********************se recibe el nombre " + cumplido);
        tempResult = misiones[numeromision].Progreso(cumplido);

        if (tempResult)
        {
            /*
             *aqui va lo de los checks
             **/
            checks[numeromision*2].SetActive(false);
            checks[numeromision*2+1].SetActive(true);
            Debug.Log("**********************se progresa mision " + numeromision);
            playerCtrl.GetComponent<Player>().regMision(numeromision);
            if (numeromision == 6)
            {
                Peticiones.instance.registerPlayerMission(misiones[6].nombre, Player.instance.playerData, Player.instance.playerData.gameStart.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                Peticiones.instance.registerPlayerPrize(logros[6].nombre, Player.instance.playerData);
                playerCtrl.GetComponent<Player>().gainEXP(6);
            }
            else if (numeromision == 7)
            {
                Peticiones.instance.registerPlayerMission(misiones[7].nombre, Player.instance.playerData, Player.instance.playerData.gameStart.ToString("yyyy-MM-dd hh:mm:ss"), DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                Peticiones.instance.registerPlayerPrize(logros[7].nombre, Player.instance.playerData);
                playerCtrl.GetComponent<Player>().gainEXP(6);
            }
        }
    }
    public void NextPage()
    {

        slothPage += 1;
        for (int i = 0; i < 4; i++)
        {
            if ((i + 4 * slothPage) < misiones.Count)
            {
                if (misiones[i + 4 * slothPage].estado == "Oculta")
                {
                    listaSloths[i].GetComponent<Text>().text = "???????????????????????";
                }
                else
                {
                    listaSloths[i].GetComponent<Text>().text = misiones[i + 4 * slothPage].nombre;
                }
            }
            else
            {
                listaSloths[i].GetComponent<Text>().text = "";
            }


        }
    }
    public void PrevPage()
    {
        if (slothPage > 0)
        {
            slothPage -= 1;
            for (int i = 0; i < 4; i++)
            {
                if ((i + 4 * slothPage) < misiones.Count)
                {
                    if (misiones[i + 4 * slothPage].estado == "Oculta")
                    {
                        listaSloths[i].GetComponent<Text>().text = "???????????????????????";
                    }
                    else
                    {
                        listaSloths[i].GetComponent<Text>().text = misiones[i + 4 * slothPage].nombre;
                    }
                }


            }
        }

    }


    public void InfMed(int medalla)
    {
        //Debug.Log("Info de medalla" + medalla);
        medallas.SetActive(false);

        medallasdetalle.SetActive(true);

        medallasdetalleTitulo.GetComponent<Text>().text = logros[medalla].nombre;
        medallasdetalleFecha.GetComponent<Text>().text = "Obtenida: " + logros[medalla].fecha;
        medallasdetalleDesc.GetComponent<Text>().text = logros[medalla].descripcion;
        medallasdetalleImagen.GetComponent<RawImage>().texture = logros[medalla].imagen.GetComponent<RawImage>().texture;



    }
    public void DisplayMed()
    {

        medallasdetalle.SetActive(false);
        medallas.SetActive(true);
    }

    public void InfMis(int mision)
    {

        if ((mision + 4 * slothPage) < misiones.Count)
        {
            titulomisiones.SetActive(false);
            misionesLista.SetActive(false);
            misionesdetalle.SetActive(true);
            if (misiones[mision + 4 * slothPage].estado == "Oculta")
            {
                misionesdetalleTitulo.GetComponent<Text>().text = "????????????????????";
                misionesdetalleEstado.GetComponent<Text>().text = "????????????????????";
                misionesEstacion.GetComponent<Text>().text = "????????????????";
                misionesRequisitos.GetComponent<Text>().text = "????????????????\n????????????????\n????????????????\n";
            }
            else
            {
                misionesdetalleTitulo.GetComponent<Text>().text = misiones[mision + 4 * slothPage].nombre;
                misionesdetalleEstado.GetComponent<Text>().text = misiones[mision + 4 * slothPage].estado;


                misionesEstacion.GetComponent<Text>().text = "Estación: ";
                foreach (int est in misiones[mision + 4 * slothPage].estacion)
                {
                    misionesEstacion.GetComponent<Text>().text = misionesEstacion.GetComponent<Text>().text + est + "    ";
                }

                misionesRequisitos.GetComponent<Text>().text = misiones[mision + 4 * slothPage].descripcion + "\n\n";
                misionesRequisitos.GetComponent<Text>().text = misionesRequisitos.GetComponent<Text>().text + "Requisitos: \n";
                if (misiones[mision + 4 * slothPage].estado == "Bloqueada")
                {
                    foreach (string req in misiones[mision + 4 * slothPage].requisitosBlock)
                    {
                        misionesRequisitos.GetComponent<Text>().text = misionesRequisitos.GetComponent<Text>().text + "-" + req + "\n";
                    }
                }
                else
                {
                    foreach (string req in misiones[mision + 4 * slothPage].requisitos)
                    {
                        misionesRequisitos.GetComponent<Text>().text = misionesRequisitos.GetComponent<Text>().text + "-" + req + "\n";
                    }
                }

                misionesRequisitos.GetComponent<Text>().text = misionesRequisitos.GetComponent<Text>().text + "\nRequisitos completados: \n";
                if (misiones[mision + 4 * slothPage].estado == "Bloqueada")
                {
                    foreach (string req in misiones[mision + 4 * slothPage].requisitosBlock)
                    {
                        misionesRequisitos.GetComponent<Text>().text = misionesRequisitos.GetComponent<Text>().text + "-" + req + "\n";
                    }
                }
                else
                {
                    foreach (string req in misiones[mision + 4 * slothPage].requisitosHechos)
                    {
                        misionesRequisitos.GetComponent<Text>().text = misionesRequisitos.GetComponent<Text>().text + "<color=green>-" + req + "</color>\n";
                    }
                }

            }




        }
        else
        {
            misionesRequisitos.GetComponent<Text>().text = "";
        }

    }
    public void DisplayMis()
    {
        titulomisiones.SetActive(true);
        misionesdetalle.SetActive(false);
        misionesLista.SetActive(true);
    }


}