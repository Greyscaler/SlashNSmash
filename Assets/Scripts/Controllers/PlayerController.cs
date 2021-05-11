using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private InputMaster controls;
    
    private Character character;


    private void Awake()
    {
        character = GetComponent<Character>();
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx => Move(0f);
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.AttackPrimary.performed += ctx => PrimaryAttack();
        controls.Player.AttackSecondary.performed += ctx => SecondaryAttack();
        controls.Player.Crouch.performed += ctx => Crouch(true);
        controls.Player.Crouch.canceled += ctx => Crouch(false);
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
    private void Crouch(bool value)
    {
        character.Crouch(value);
    }
    private void PrimaryAttack()
    {
        character.PrimaryAttack();
    }
    private void SecondaryAttack()
    {
        character.SecondaryAttack();
    }
}
