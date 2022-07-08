using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntero : MonoBehaviour
{
    public Sprite knob;
    public Sprite finger;

    public void puntero()
    {
        this.gameObject.GetComponent<Image>().sprite=finger;
        this.gameObject.transform.localScale =new Vector3(5,5,5);
    }
    public void mira()
    {
        this.gameObject.GetComponent<Image>().sprite = knob;
        this.gameObject.transform.localScale = new Vector3(1, 1, 1);
    }
}
