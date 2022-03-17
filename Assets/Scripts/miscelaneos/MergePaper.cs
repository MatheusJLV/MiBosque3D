using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergePaper : Desafio
{
    public GameObject fpsPlayer;

    public override void Start()
    {
        base.Start();
        DialogoConfirmacion();
    }

    private void DialogoConfirmacion()
    {

        IntroductionDialog();

        fpsPlayer.GetComponent<ShowBook>().enabled = true;

    }
}