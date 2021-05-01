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
    int isWalkingHash;
    bool isWalking = false;


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
        isWalkingHash = Animator.StringToHash("IsWalking");
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
        if (isWalking)
        {   
            characterController.Move(new Vector3(direction, 0, 0).normalized * speed * Time.deltaTime);
        }
       
        if (Mathf.Abs(direction) >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction, 0) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, smooth);
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
       
    }
    private void Move(float value)
    {
        if (value != 0f)
        {
            direction = value;
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        animator.SetBool(isWalkingHash, isWalking);
    }
    private void Jump()
    {

    }
    private void Crouch()
    { 
    
    }
}
