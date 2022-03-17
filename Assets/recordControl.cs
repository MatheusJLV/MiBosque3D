using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recordControl : MonoBehaviour
{
    private GameObject recordatorio;
    // Start is called before the first frame update
    void Start()
    {
        recordatorio = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            recordatorio.GetComponent<Animator>().SetBool("show", true);
        }
    }
}
