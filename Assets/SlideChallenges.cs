using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideChallenges : MonoBehaviour
{
    public Sprite[] imageArray;
    private int currentImage;
    float deltaTime = 0.0f;
    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool isRunning = true;
    public string timer1Text;
    public GameObject imagen;
    public bool PreguntasReader=false;
    public GameObject actionLogger;
    // Start is called before the first frame update

    void Start()
    {
        actionLogger = GameObject.Find("ActionLogger");
        PlayerData player = GameManager.instance.playerData;
        actionLogger.GetComponent<ActionLogger>().actionLogger.player = player.nombre + "-" + player.UserName + "-" + player.PassWord + "-" + player.Token;

        //if (Input.GetKeyUp(KeyCode.B))
        {
            Peticiones.instance.getPreguntas(GameManager.instance.playerData);
        }
        
        }

    // Update is called once per frame
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        if (isRunning)
        {
            if (timer1Remaining>0)
            {
                timer1Remaining -= Time.deltaTime;
            }
            else
            {
                currentImage++;
                if (currentImage>=imageArray.Length)
                {
                    currentImage = 0;
                }
                timer1Remaining = timer1;
            }
        }
    }
    public void imgChange(int estacion)
    {
        try
        {
            currentImage = estacion-1;
            timer1Remaining = timer1 * 2;
        }
        catch(Exception e)
        {

        }
    }
    private void OnGUI()
    {
        int w = Screen.width, h = Screen.height;
        Rect imageRect = new Rect(0,0,Screen.width,Screen.height);
        //GUI.DrawTexture(imageRect,imageArray[currentImage]);
        this.GetComponent<SpriteRenderer>().sprite = imageArray[currentImage];
        if (currentImage>=imageArray.Length)
        {
            currentImage = 0;
        }
    }
}
