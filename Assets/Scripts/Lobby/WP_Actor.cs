using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WP_Actor : MonoBehaviour
{
    float speed = 5.0f;
    public Transform target;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", speed);
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "waypoint") {
            Debug.Log("entra");
            target = other.gameObject.GetComponent<WayPoint>().nextPoint;
            transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
            speed = 0f;
            animator.SetFloat("speed", speed);
            transform.Translate(new Vector3(0, 0,0));
        }
    }
}
