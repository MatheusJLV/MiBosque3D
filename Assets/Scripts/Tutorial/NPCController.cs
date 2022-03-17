using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public Transform[] target;
    public float speedRun;
    public float speedWalk;
    private float currentSpeed;

    private int current;

    public bool stateWalk;
    public bool stateRun;
    public bool stateJump;

    public GameObject alert;


    Animator anim;

    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {    
        autoRotateNPC();
        moves();
        activeAlert();
    }

    // move the NPC in the tutorial space
    void moves()
    {
         if(stateWalk){
            

            Vector3 nextPos = Vector3.MoveTowards(transform.position, target[0].position, currentSpeed*Time.deltaTime);            

            if(transform.eulerAngles.y > 0)
            {
                transform.Rotate(0.0f, 1.0f*10.0f, 0.0f);
            }

            anim.SetInteger("Status",1);

            GetComponent<Rigidbody>().MovePosition(nextPos);

           

                     
        }

         if(stateRun){
            

            Vector3 nextPos = Vector3.MoveTowards(transform.position, target[1].position, currentSpeed*Time.deltaTime);

            if(transform.eulerAngles.y > 80)
            {
                transform.Rotate(0.0f, -1.0f*10.0f, 0.0f);
            }

            anim.SetInteger("Status",2);

            GetComponent<Rigidbody>().MovePosition(nextPos);            
        }

        if(stateJump){

            Vector3 nextPos = Vector3.MoveTowards(transform.position, target[2].position, currentSpeed*Time.deltaTime);

            anim.SetInteger("Status",3);

            GetComponent<Rigidbody>().MovePosition(nextPos);
        }

    }

    // change the boolean value
    public void stateWalking()
    {
        stateWalk = true;
        currentSpeed = speedWalk;        
    }

    // change the boolean value
    public void stateRunning()
    {
        stateRun = true;
        currentSpeed = speedRun;
    }

    // change the boolean value
    public void stateJumping()
    {
        stateWalk = false;
        stateRun = false;
        stateJump = true;
    }

    // change the boolean value
    public void stateIdle()
    {
        stateWalk = false;
        stateRun = false;
        stateJump = false;
        anim.SetInteger("Status", 0);
    }

    //rotate the npc on a point in the scene
    void autoRotateNPC()
    {      

        if(Vector3.Distance(transform.position, target[0].position) < 0.7)
        {
            stateWalk = false;

            anim.SetInteger("Status", 0);

            if(transform.eulerAngles.y < 170)
            {
                transform.Rotate(0.0f, 1.0f*10.0f, 0.0f);
            }

            alert.SetActive(true);
           
        }

        if(Vector3.Distance(transform.position, target[1].position) < 1)
        {
            stateRun = false;
            
            anim.SetInteger("Status", 0);

            if(transform.eulerAngles.y < 260)
            {
                transform.Rotate(0.0f, 1.0f*10.0f, 0.0f);
            }

            alert.SetActive(true);
           
        }
           
                
    }

    void activeAlert()
    {
        if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < 2.5)
        {
            alert.SetActive(false);
        }
    }

    
}
