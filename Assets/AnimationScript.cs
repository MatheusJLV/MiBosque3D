using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationScript : MonoBehaviour
{
    public Animator animalName;
    //public Text st;
    // Start is called before the first frame update
    void Start()
    {
        inicio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inicio() {

        animalName.SetBool("IsActive", true);

    }

    public IEnumerator LateCall()
    {
        yield return new WaitForSeconds(2);
        animalName.SetBool("IsActive", false);
    }




}
