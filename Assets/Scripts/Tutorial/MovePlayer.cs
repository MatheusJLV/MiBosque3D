using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public bool canMove = false;
    
    CharacterController controller;

    float speed;
    public float speedWalk = 2f;
    public float speedRun = 8f;
    public float jump = 0.7f;
    public float gravity = -10f;

    public Transform groundCheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

       
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        speed = speedWalk;        
    }

    // Update is called once per frame
    void Update()
    {
       if(canMove)
       {
           Move();
           run();           
       }
       
    }

    void Move()
    {
          isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

          if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * x + transform.forward * z;


        controller.Move(movement * speed * Time.deltaTime);

         if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
        }
       
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        
    }


    void run()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = speedRun;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = speedWalk;
        }
    }

    public void moveActive(bool condition)
    {
       canMove = condition;
    }
}
