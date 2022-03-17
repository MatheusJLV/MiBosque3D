using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public Transform[] positions;
    public float speed, rotationSpeed;

    int posIndex;
    Transform nextPos, player;
    bool active, isFinished;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        posIndex = 0;
        nextPos = positions[0];
        active = false;
        isFinished = false;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (active)
        {
            if (animator != null)
                animator.enabled = false;
            Move();
        }
    }

    void Move()
    {
        if (player != null)
            player.position = transform.position;
        if (transform.position == nextPos.position)
        {
            if (posIndex + 1 >= positions.Length)
            {
                active = false;
                isFinished = true;
                animator.enabled = true;
                return;
            }
            nextPos = positions[++posIndex];
        }
        else
        {
            
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);


            Vector3 directionToFace = transform.position - nextPos.position;
            //transform.rotation = Quaternion.LookRotation(directionToFace);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(directionToFace), rotationSpeed * Time.deltaTime);
            
        }
    }

    public void ActiveMovement(Transform playerTransform)
    {
        active = true;
        player = playerTransform;
    }

    public bool IsFinished()
    {
        return isFinished;
    }
}
