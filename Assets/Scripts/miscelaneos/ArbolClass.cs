using UnityEngine;
using System.Collections;

namespace ArbolClass {

    [System.Serializable]
    public class Arbol : MonoBehaviour {
        public string SpecieId;
        public int Id;
        public string Name;
        public string Family;
        public Gallery[] Gallery; 
    }

    [System.Serializable]
    public class Gallery : MonoBehaviour {
        public string PhotoId;
        public int Id;
        public string Descripcion;
    }
}