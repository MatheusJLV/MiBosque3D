using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback2Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(endPanel());
    }

    IEnumerator endPanel()
    {
        yield return new WaitForSeconds(7.0f);
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
