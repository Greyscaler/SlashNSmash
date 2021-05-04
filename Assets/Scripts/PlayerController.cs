using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private InputMaster controls;
    private float _direction;
   
   
    Imovable moveCharacter;
    IJump jumpCharacter;


    private void Awake()
    {   
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx => Move(0f);
        controls.Player.Jump.performed += ctx => Jump();
    }
    private void Start()
    {
        moveCharacter = GetComponent<Imovable>();
        jumpCharacter = GetComponent<IJump>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
     private void Move(float value)
    {
        moveCharacter.SetTranslate(new Vector3(value, 0, 0));
    }
    private void Jump()
    {
        jumpCharacter.Jump();
        
    }
    private void Crouch()
    { 
    
    }
}
