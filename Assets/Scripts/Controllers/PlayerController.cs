using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    //private InputMaster controls;
    
    private Character character;
  
    private void Awake()
    {
        
        character = GetComponent<Character>();
        /*
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>(),ctx);
        controls.Player.Movement.canceled += ctx => Move(0f, ctx);
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.AttackPrimary.performed += ctx => PrimaryAttack();
        controls.Player.AttackSecondary.performed += ctx => SecondaryAttack();
        controls.Player.Crouch.performed += ctx => Crouch(true);
        controls.Player.Crouch.canceled += ctx => Crouch(false);
        */
    }

    private void OnEnable()
    {
        //controls.Enable();
    }
    private void OnDisable()
    {
        //controls.Disable();
    }
    public void Move(InputAction.CallbackContext ctx)
    {
        if(ctx.performed)
        {
            character.Move(new Vector3(ctx.ReadValue<float>(), 0, 0));
        }
        else if(ctx.canceled)
        {
            character.Move(new Vector3(0, 0, 0));
        }
        
    }
    
    public void Jump(InputAction.CallbackContext ctx)
    {   
        character.Jump();
    }
    public void Crouch(InputAction.CallbackContext ctx)
    {
        character.Crouch(true);
    }
    public void PrimaryAttack(InputAction.CallbackContext ctx)
    {
        character.PrimaryAttack();
    }
    public void SecondaryAttack(InputAction.CallbackContext ctx)
    {
        character.SecondaryAttack();
    }
}
