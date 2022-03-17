using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    public TargetCollectObject target;
    public void GetCollected()
    {
        if (!target.IsCompleted())
        {
            target.CollectOne();
        }
        if (!target.isInteractive)
        {
            target.UpdateCounter();
        }
        Destroy(gameObject);
    }
}
