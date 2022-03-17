
using System.Collections.Generic;
namespace DataApi
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Direccion
    {
        public string sector { get; set; }
        public string city { get; set; }
        public string location { get; set; }
    }

    public class DataInstituciones
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<string> typeOfEducation { get; set; }
        public string typeOfInstitution { get; set; }
        public Direccion direccion { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string facebook { get; set; }
        public string instagram { get; set; }
        public string twitter { get; set; }
    }

    public class Root
    {
        public List<DataInstituciones> DataInstituciones { get; set; }
    }

    public class Estudiante
    {
        public string id { get; set; }
        public string identification { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string dateOfBirth { get; set; }
        public string player { get; set; }
        public object user { get; set; }
        public string institution { get; set; }
    }



}
