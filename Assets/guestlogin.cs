using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guestlogin : MonoBehaviour
{
    public InputField codigo;
    public int guest=4747;
    public void OnMouseDown()
    {
        Debug.Log("clic");
        codigo.text = ""+guest;
        this.GetComponent<Text>().text = "Ahora puedes jugar como invitado con el código " + guest +" cuando quieras!";
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
