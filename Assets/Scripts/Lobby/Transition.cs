using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{

    public Animator transition;  
    // Start is called before the first frame update
    void Start()
    {
        transition = GetComponent<Animator>();

    }

    public void LoadScene(string scene)
    {
        StartCoroutine(Transiona(scene));
    }

    IEnumerator Transiona(string scene)
    {
        transition.SetTrigger("salida");
        yield return new WaitForSeconds(1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
