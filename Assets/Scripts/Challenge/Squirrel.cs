using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squirrel : MonoBehaviour
{
    public Transform target;
    float Speed = 10f; //Antes era 10f
    float RotationalDamp = 0.5f;
    private bool inside;
    private Animator animator;
    public static bool caught = false;
    public static bool activate = false;
    public GameObject img;
    public Text timeText;
    public float _timer = 10.0f;
    private float timer;
    public GameObject skin;
    public AudioScript clockSound;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        timer=_timer;
    }

    private void Update()
    {
        if (!inside)
        {
            transform.LookAt(this.transform);
            animator.SetBool("Run",false);

        }
        else
        {
            if(!caught)
            {
                animator.SetBool("Run",true);
                Turn();
                Move();
            }else
            {
                animator.SetTrigger("Caught");
                TakeHome();
                GameObject.FindGameObjectWithTag("Rabbit").GetComponent<CapsuleCollider>().enabled = false;
                img.SetActive(true);
                skin.SetActive(false);
                timer -= Time.deltaTime;
                timeText.text = "" + timer.ToString("f0");
                if(timer<=-1)
                {
                    clockSound.detener();
                    caught = false;
                    GameObject.FindGameObjectWithTag("Rabbit").GetComponent<CapsuleCollider>().enabled = true;
                    img.SetActive(false);
                    timer = _timer;
                    skin.SetActive(true);
                }
                if (!activate)
                {
                    //Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    img.SetActive(false);
                    clockSound.detener();
                }
                
            }
            
        }
        
    }

    private void Move()
    {
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    private void Turn()
    {
        Vector3 pos = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(pos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, RotationalDamp * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inside = false;
        }
    }

    private void OnMouseDown()
    {
        if (activate && !(MenuPausa.IsPaused || MenuPausa.IsPausedByOtherCanvas))
        {
            StartCoroutine(TimeCapture());
        }
    }

    IEnumerator TimeCapture()
    {
        caught = true;
        clockSound.reproducir();
        yield return new WaitForSeconds(10.0f);
        clockSound.detener();
        caught = false;
        GameObject.FindGameObjectWithTag("Rabbit").GetComponent<CapsuleCollider>().enabled = true;
        img.SetActive(false);
        timer = _timer;
        skin.SetActive(true);
    }

    private void TakeHome()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
    }
}
