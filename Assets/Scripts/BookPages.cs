using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System;

public class BookPages : MonoBehaviour
{
    public static BookPages instance;
    public Texture[] imagenes;
    public string[] nombres;
    public bool[] isDiscovered;

    public bool[] isLoaded; //Variable para comprobar que esten cargados pero no descubiertos

    public string[] descripciones;
    public string[] estaciones;
    public string[] nombresLatin;
    public string[] familias;
    public string[] otrosHabitats;

    public GameObject leftPage;
    public GameObject rightPage;
    public Button nextPage;
    public Button previousPage;
    private string webRequestUrl;
    private string imageRequestUrl;
    private Arbol tree;//Esto es para almacenar el Json al hacer un httprequest

    public bool isOpen;
    public bool pagesLoaded;
    public int paginaActual;


    public Sprite[] test;
    private int controlador = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        isOpen = false;
        pagesLoaded = false;
        paginaActual = 0;
        webRequestUrl = SystemVariables.url_puerto + "/api/bpv/specie?name=";
        imageRequestUrl = SystemVariables.url_puerto + "/api/bpv/specie/";

        //test = new Sprite[17];
        imagenes = new Texture[17];
        descripciones = new string[17];

        nombres = new string[17] {"Teca","Ceibo","Bototillo","Pechiche","Guasmo","Fernan Sánchez",
            "Iguana","Ardilla", "Momoto Gritón","Pinzón Sabanero","Gavilán Gris","Garrapatero Piquiestrado",
            "Tangara Azul y Gris", "Búho Blanquinegro", "Garcilla Estriada", "Tirano Tropical","Mosquero Rayado"};

        nombresLatin = new string[17] { "Tectona Grandis", "Erythrina Cristagalli", "Cochlospermum vitifolium", "Vitex cymosa", "Guazuma ulmifolia", "Triplaris cumingiana",
            "Iguana iguana", "Sciurus stramineus", "Momotus subrufescens", "Sicalis flaveola", "Buteo nitidus", "Crotophaga sulcirostris",
            "Thraupis episcopus", "Strix nigrolineata", "Butorides striata", "Tyrannus melancholicus", "Myiodynastes maculatus" };

        familias = new string[17] { "Verbenaceae", "Faboideae", "Bixaceae", "Lamiaceae", "Malvaceae", "Polygonaceae",
            "Iguanidae", "Sciuridae", "Momotidae", "Emberizidae", "Accipitridae", "Cuculidae",
            "Thraupidae", "Strigidae", "Ardeidae", "Tyrannidae", "Tyrannidae" };

        otrosHabitats = new string[17] { "India, Birmania, Laos, Tailandia", "Argentina, Bolivia, Brasil", "México", "Panamá, Antillas, Venezuela", "México", "Colombia",
            "Centroamérica, Caribe", "Cordillera de los Andes", "Panamá, Colombia, Venezuela", "Argentina, Brasil, Panamá", "Costa Rica", "USA, Bahamas, Centroamérica",
            "Costa Rica, Panamá, Perú", "Guatemala, Honduras, Nicaragua", "Japón, África Oriental, Australia", "Argentina, Perú, Trinidad y Tobago", "Brasil, Paraguay, Bolivia" };

        setearInfo();
        estaciones = new string[17];
        isLoaded = new bool[17];
    }

    //TESTEO

    void setearInfo()
    {
        /*
        if (controlador < 17)
        {
            string[] dbDescripciones = ConstantObjects.instance.descripciones;
            for (int i = 0; i < 17; i++)
            {
                imagenes[i] = test[i].texture;
                descripciones[i] = dbDescripciones[i];
                controlador++;
            }
        }
        */
        for (int i = 0; i < 17; i++)
        {
            foreach (SpecieObject specie in GameManager.instance.test.species)
            {
                if (nombres[i].Equals(specie.Name))
                {
                    imagenes[i] = test[i].texture;
                    descripciones[i] = specie.Gallery[0].Description;
                }
            }
        }

    }

    //FIN TESTEO


    private void Update()
    {
        if (isOpen && !pagesLoaded)
        {
            cargarPagina(paginaActual);
        }
    }

    public void registrarEspecie(string especie, string estacion)
    {
        for (int indice = 0; indice < nombres.Length; indice++)
        {
            isLoaded[indice] = true;
            if (nombres[indice].Equals(especie))
            {
                isDiscovered[indice] = true;
                estaciones[indice] = estacion;
                return;
            }
        }
        Debug.Log("No encontro la especie");
    }

    public void paginaSiguiente()
    {

        if (paginaActual + 1 < 8)//Maximo 9 pares de paginas, porque son 17 especies.
        {
            Debug.Log("Presiono pagina siguiente y esta dentor del if.");
            paginaActual++;
            pagesLoaded = false;
        }
    }

    public void paginaAnterior()
    {
        if (paginaActual - 1 >= 0)
        {
            Debug.Log("Presiono pagina anterior y esta dentor del if.");
            paginaActual--;
            pagesLoaded = false;
        }
    }

    //Se llena por par de paginas
    //CAMBIAR ESTO PARA QUE SE AJUSTE A CONTENIDO ESTATICO DE 12 ELEMENTOS MAXIMO
    //RECORDAR QUE SI NO ESTA DESCUBIERTO UN ELEMENTO HAY QUE CAMBIAR LA SATURACION Y CONTRASTE DE LA FOTO
    //ADEMAS DE OCULTAR LOS DATOS, SI ESTA DESCUBIERTO HACER LLAMADO HTTP PARA DESCRIPCION.
    private void cargarPagina(int nPagina)
    {

        int izq = nPagina * 2; //Estos numeros son los indices de las especies en los arreglos.
        int der = izq + 1;

        leftPage.transform.Find("Nombre").GetComponent<Text>().text = nombres[izq];
        //StartCoroutine(CargarInfo(nombres[izq], izq));

        if (isDiscovered[izq])
        {
            //Codigo que sirve para cambiar el contraste de la imagen si este ya fue descubierto (Desde el inicio)
            var tempColor = leftPage.transform.Find("Imagen").GetComponent<RawImage>().color;
            tempColor.a = 1.0f;
            leftPage.transform.Find("Imagen").GetComponent<RawImage>().color = tempColor;

            leftPage.transform.Find("Imagen").GetComponent<RawImage>().texture = imagenes[izq];
            leftPage.transform.Find("Estacion").GetComponent<Text>().text = estaciones[izq];
            leftPage.transform.Find("Descripcion").GetComponent<Text>().text = descripciones[izq];
            leftPage.transform.Find("NomLatin").GetComponent<Text>().text = nombresLatin[izq];
            leftPage.transform.Find("Familia").GetComponent<Text>().text = familias[izq];
            leftPage.transform.Find("OtrosHabitats").GetComponent<Text>().text = otrosHabitats[izq];
        }
        else
        {
            //Codigo que sirve para cambiar el contraste de la imagen si este no ha sido descubierto (Desde el inicio)
            var tempColor = leftPage.transform.Find("Imagen").GetComponent<RawImage>().color;
            tempColor.a = 0.35f;
            leftPage.transform.Find("Imagen").GetComponent<RawImage>().color = tempColor;

            leftPage.transform.Find("Imagen").GetComponent<RawImage>().texture = imagenes[izq];
            leftPage.transform.Find("Estacion").GetComponent<Text>().text = "No hay datos.";
            leftPage.transform.Find("Descripcion").GetComponent<Text>().text = "No hay datos.";

            leftPage.transform.Find("NomLatin").GetComponent<Text>().text = "No hay datos.";
            leftPage.transform.Find("Familia").GetComponent<Text>().text = "No hay datos.";
            leftPage.transform.Find("OtrosHabitats").GetComponent<Text>().text = "No se han descubierto.";
        }


        //StartCoroutine(CargarInfo(nombres[der], der));
        //Se debe verificar si ambas paginas estan completas, puede que solo la izq tenga elementos.
        if (der < nombres.Length)
        {
            rightPage.transform.Find("Nombre").GetComponent<Text>().text = nombres[der];
            if (isDiscovered[der])
            {
                //StartCoroutine(CargarInfo(nombres[der], der));
                //Codigo que sirve para cambiar el contraste de la imagen si este ya fue descubierto (Desde el inicio)
                var tempColor = rightPage.transform.Find("Imagen").GetComponent<RawImage>().color;
                tempColor.a = 1.0f;
                rightPage.transform.Find("Imagen").GetComponent<RawImage>().color = tempColor;

                rightPage.transform.Find("Imagen").GetComponent<RawImage>().texture = imagenes[der];
                rightPage.transform.Find("Estacion").GetComponent<Text>().text = estaciones[der];
                rightPage.transform.Find("Descripcion").GetComponent<Text>().text = descripciones[der];

                rightPage.transform.Find("NomLatin").GetComponent<Text>().text = nombresLatin[der];
                rightPage.transform.Find("Familia").GetComponent<Text>().text = familias[der];
                rightPage.transform.Find("OtrosHabitats").GetComponent<Text>().text = otrosHabitats[der];
            }
            else
            {


                //Codigo que sirve para cambiar el contraste de la imagen si este no ha sido descubierto (Desde el inicio)
                var tempColor = rightPage.transform.Find("Imagen").GetComponent<RawImage>().color;
                tempColor.a = 0.35f;
                rightPage.transform.Find("Imagen").GetComponent<RawImage>().color = tempColor;



                rightPage.transform.Find("Imagen").GetComponent<RawImage>().texture = imagenes[der];
                rightPage.transform.Find("Estacion").GetComponent<Text>().text = "No hay datos.";
                rightPage.transform.Find("Descripcion").GetComponent<Text>().text = "No hay datos.";

                rightPage.transform.Find("NomLatin").GetComponent<Text>().text = "No hay datos.";
                rightPage.transform.Find("Familia").GetComponent<Text>().text = "No hay datos.";
                rightPage.transform.Find("OtrosHabitats").GetComponent<Text>().text = "No se han descubierto.";

            }
        }

        pagesLoaded = true;
    }

    //Falta implementar webRequests para la informacion
    /*
    public IEnumerator CargarInfo(string name, int posEspecie)
    {

        UnityWebRequest www = UnityWebRequest.Get(webRequestUrl + name);
        www.SetRequestHeader("Authorization", GameManager.authToken);
        Debug.Log("URL de la info:" + webRequestUrl + name);
        yield return www.SendWebRequest();

        if (www.responseCode.Equals(401))
        {
            StartCoroutine(GameManager.getAuthToken());
            www.SetRequestHeader("Authorization", GameManager.authToken);
            yield return www.SendWebRequest();
        }
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string data = www.downloadHandler.text;
            try
            {
                tree = JsonUtility.FromJson<Arbol>(data);
                descripciones[posEspecie] = tree.Gallery[0].Description;
                //StartCoroutine(LoadImage(tree.Gallery[0].Id, posEspecie));

            }
            catch (System.Exception)
            {
                Debug.Log("No hay datos de este árbol");
            }
        }

        //CargarImagen(0);
    }
    */
    public IEnumerator LoadImage(int id, int posEspecie)
    {

        UnityWebRequest w = UnityWebRequestTexture.GetTexture(imageRequestUrl + tree.Id + "/gallery/" + id + "/");
        Debug.Log("URL de la imagen: " + imageRequestUrl + tree.Id + "/gallery/" + id + "/");
        yield return w.SendWebRequest();
        if (w.isNetworkError || w.isHttpError)
        {
            Debug.Log(w.error);
        }
        else
        {
            imagenes[posEspecie] = ((DownloadHandlerTexture)w.downloadHandler).texture;

        }
    }

    public void SaveBook()
    {
        GameManager.instance.playerData.isDiscovered = this.isDiscovered;
    }

    /*public void CargarInfo(string name, int posEspecie)
    {
        foreach(SpecieObject specie in GameManager.instance.test.species){
            if(specie.Name == name){
                tree = new Arbol();
                tree.SpecieId = specie.SpecieId;
                tree.Id = specie.Id;
                tree.Name = specie.Name;
                tree.Family = specie.Family;
                tree.Gallery = specie.Gallery;
                descripciones[posEspecie] = tree.Gallery[0].Description;
            }
        }
    }

    public void LoadImage(int id, int posEspecie)
    {
        imagenes[posEspecie] = LoadTextureFromFile(id + ".jpg");
    }

    private Texture2D LoadTextureFromFile(string filename)
    {
        Texture2D tex = null;
        string filePath = Application.dataPath + SystemVariables.image_url + filename;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData);
        }
        return tex;
    }*/
}
