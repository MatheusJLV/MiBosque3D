public static class SystemVariables{
    public static readonly string url="http://200.126.14.250";
    public static readonly string puerto="8080";
    public static readonly string url_puerto=url+":"+puerto;
    public static readonly string image_url = "/GreenForest/Data/Species/Images/";
    public static readonly string audio_url = "/GreenForest/Data/Species/Audios/";
    public static readonly string info_url = "/GreenForest/Data/Species/Descriptions/";
    public static readonly string list_species = url_puerto + "/api/bpv/specie/list";
    public static readonly string[] list = new string[] { "Teca", "Ceibo", "Bototillo", "Pechiche", "Guasmo", "Fernan S�nchez", "Iguana", "Ardilla", "Momoto Grit�n", "Pinz�n Sabanero", "Gavil�n Gris", "Garrapatero Piquiestriado", "Tangara Azul y Gris", "B�ho Blanquinegro", "Garcilla Estriada", "Tirano Tropical", "Mosquero Rayado" };
    public static readonly string WebInfo = url_puerto + "/api/bpv/specie?name=";
    public static readonly string WebImaAud = url_puerto + "/resources/bpv/images/species/";
    public static readonly string question_url = "/GreenForest/Data/Questions/";

}