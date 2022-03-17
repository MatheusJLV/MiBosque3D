using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmacionExito : Desafio
{

    public void Completado()
    {
        Invoke("IntroductionDialog", 2f);
        //DesbloquearLibro.active = true;
        
    }

    private void Update() {
        if (dialogoCompletado){
            dialogoCompletado=false;
            Destroy(this.gameObject);
        }
    }
}
