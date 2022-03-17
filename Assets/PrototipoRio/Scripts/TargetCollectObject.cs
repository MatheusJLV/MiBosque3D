using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetCollectObject : MonoBehaviour
{
    public int maxNumberCollectables;
    [SerializeField] int actualNumberCollectables = 0;

    public TextMeshPro contadorText;
    public bool isMovable, isInteractive;

    void Update()
    {
        UpdateCounter();
    }

    public void CollectOne()
    {
        actualNumberCollectables++;
    }

    public void UpdateCounter()
    {
        contadorText.text = actualNumberCollectables.ToString() + "/" + maxNumberCollectables.ToString();
    }

    public bool IsCompleted()
    {
        return actualNumberCollectables >= maxNumberCollectables;
    }
}
