using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class JoystickController : MonoBehaviour
{
    public FixedJoystick moveJoystick;
    public FixedButton jumpButton;
    public FixedTouchField touchField;
    public FirstPersonController fps;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        fps.RunAxis = moveJoystick.Direction;
        fps.JumpAxis = jumpButton.Pressed;
        fps.m_MouseLook.LookAxis = touchField.TouchDist; 
    }
}
