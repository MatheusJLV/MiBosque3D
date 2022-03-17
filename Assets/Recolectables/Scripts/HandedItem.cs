using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandedItem : MonoBehaviour
{
    void Update()
    {
        if (this.transform.childCount > 1)
        {
            PickupObject[] pickups = this.GetComponentsInChildren<PickupObject>();
            for (int i = 1; i < pickups.Length; i++)
            {
                pickups[i].ThrowItem();
            }
        }
    }

    public bool isEmpty()
    {
        return this.transform.childCount == 0;
    }
}
