using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private InputMaster controls;
    private float _direction;
   
    Imovable moveCharacter;


    private void Awake()
    {   
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx => Move(0f);
    }
    private void Start()
    {
        moveCharacter = GetComponent<Imovable>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
  
    private void FixedUpdate()
    {
        moveCharacter.Translate(_direction);
        moveCharacter.Rotate(_direction);
    }
    private void Move(float value)
    {
        _direction = value;
    }
    private void Jump()
    {

    }
    private void Crouch()
    { 
    
    }
}
