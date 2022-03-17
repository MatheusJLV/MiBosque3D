using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBlink : MonoBehaviour
{
    
    Animator anim;

    float segundos;

    public string state;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        segundos += Time.deltaTime;

        if(segundos >= 0.19f)
        {
            anim.enabled = false;
            anim.Rebind();
            
            if(segundos >= 5)
            {
                anim.enabled = true;
                segundos = 0;
            }
        }
        
    }
}
