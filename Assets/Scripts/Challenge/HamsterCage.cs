using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterCage : MonoBehaviour
{
    public List<GameObject> animals;
    private int salIndex = 0;
    private int ratIndex = 1;
    public GameObject selectedItem;


    public void ActivateRat()
    {
        animals[ratIndex++].SetActive(true);
    }

    public void ActivateSal()
    {
        animals[salIndex].SetActive(true);
    }

    private void Update()
    {
        if (this.transform.parent.Equals(selectedItem.transform))
            this.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else
        {
            this.transform.localScale = Vector3.one;
        }
    }

}
