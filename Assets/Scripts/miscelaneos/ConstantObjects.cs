using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantObjects : MonoBehaviour
{
    public Collider cameraBlocker;
    public MouseController mouseController;
    public static ConstantObjects instance;

    // Descripciones especies
    public string[] descripciones;

    private void Awake()
    {
        descripciones = new string[17]
            {
                "Es un árbol frondoso, se usa para la fabricación de muebles y embarcaciones lujosas.",
                "Es una especie nativa de la tierra latinoamericana.",
                "La floración del árbol Bototillo es de un amarillo intenso, dura de 3 a 4 semanas.",
                "Su nombre científico es Vitex gigantea Kunth es un arbol que llega a medir 20 m. de alto.",
                "Es un árbol de porte bajo con hojas simples y produce flores pequeñas.",
                "Ampliamente distribuido en bosques húmedos, incluyendo llanuras de ríos y bosques secos.",
                "A pesar de su tamaño, pueden moverse velozmente entre las plantas y son excelentes trepadoras.",
                "La ardilla es un mamífero roedor. Mide entre 35 y 45 cm de longitud, de las que casi la mitad pertenecen a la cola.",
                "Suele permanecer perchado mientras analiza sus alrededores realizando un movimiento pendular de la cola.",
                "Miden 14 cm. Se alimentan de granos y semillas que encuentran en el suelo. Construyen nidos en árboles aislados.",
                "Se alimenta de una variedad de presas, generalmente desde su percha. Planea, por poco tiempo y poca altura.",
                "Su plumaje es completamente negro con tonos azules y tiene el pico aplastado a los lados con ranuras alargadas, muy marcadas.",
                "Esta hermosa ave que se alimenta principalmente de frutos lleva el nombre Tangara Azuleja por el color de su plumaje.",
                "Activo únicamente por la noche, duerme bajo frondoso arboledo, a menudo en ramas expuestas a gran altura del suelo.",
                "Es una especie de tamaño mediano, caza de pie o en cuclillas, normalmente es algo solitaria.",
                "Se alimenta principalmente de insectos que capturan con sus vaivenes aéreos, también consume fruta.",
                "Hallado sólo o en pareja, generalmente ruidoso y conspicuo. Persigue una gran variedad de insectos, algunos capturados mediante vaivenes aéreos. También se alimenta de fruta."
            };
        instance = this;
    }
}
