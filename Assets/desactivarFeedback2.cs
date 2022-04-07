using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivarFeedback2 : MonoBehaviour
{
    public GameObject feedback2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj)
    {
#if UNITY_ANDROID || UNITY_IOS
        //joystick.SetActive(false);
#endif
        if (obj.gameObject.tag == "Player")
        {
            feedback2.SetActive(false);
        }
    }
}
