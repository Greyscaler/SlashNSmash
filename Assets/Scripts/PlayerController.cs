using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    private InputMaster controls;
    private Animator animator;
    private CharacterController characterController;
    public float speed = 12f;
    private float direction;
    private float rotationDirection;
   
    public float smooth = 1.0f;
    private float turnVelocity;


    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Player.Movement.canceled += ctx => Move(0f);
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
    private void OnDestroy()
    {
        
    }

    private void FixedUpdate()
    {
        if (direction != 0)
        {
            rotationDirection = direction;
            characterController.Move(new Vector3(direction, 0, 0).normalized * speed * Time.deltaTime);
            
        }
       
        if (Mathf.Abs(rotationDirection) >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(rotationDirection, 0) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, smooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
    private void Move(float value)
    {
        direction = value;
        if (direction != 0)
        {
            animator.SetTrigger("Walk");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
    }
    private void Jump()
    {

    }
    private void Crouch()
    { 
    
    }
}
