using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private InputMaster controls;
    private float _direction;

    private Character character;


    private void Awake()
    {
        character = GetComponent<Character>();
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx => Move(0f);
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.AttackPrimary.performed += ctx => PrimaryAttack();
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
        character.Move(new Vector3(value,0,0));
    }
    private void Jump()
    {
        character.Jump();
        
    }
    private void Crouch()
    { 
    
    }
    private void PrimaryAttack()
    {
        character.PrimaryAttack();
    }
}
