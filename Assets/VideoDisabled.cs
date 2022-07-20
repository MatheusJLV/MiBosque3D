using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoDisabled : MonoBehaviour
{
    public void OnDisable()
    {
        Debug.Log("video minimizado");
        MenuPausa.instance.Reanudar();
    }
}
