using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    private Alteruna.Avatar avatar; // declare avatar
    public PlayerInput.OnFootActions OnFoot => onFoot;

    void Awake()
    {
        avatar = GetComponent<Alteruna.Avatar>(); //initialize avatar

        //if (!avatar.IsMe)//checks if player owns the current player object
        //    return;//if not then dont execute this code

        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctx => motor.Jump();
        onFoot.Crouch.performed += ctx => motor.Crouch();
        onFoot.Sprint.performed += ctx => motor.Sprint();
    }

    void FixedUpdate()
    {
        //if (!avatar.IsMe)//checks if player owns the current player object
           // return;//if not then dont execute this code

        // Tells the PlayerMotor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    void LateUpdate()
    {
        if (!avatar.IsMe)//checks if player owns the current player object
            return;//if not then dont execute this code

        // Tells the PlayerLook to process look input
        look.ProcesssLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}