using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultJump : MonoBehaviour, IJump
{
    [SerializeField] private float _height;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpAnimationDelay = 0.15f;
    [SerializeField] private float _jumpRate = 1f;
    private float _jumpTime = 0f;


    private CharacterController _characterController;
    private Vector3 _velocity;
    private float gravity;
    private Animator _animator;


    private bool isGrounded = false;
    private Transform _groundCheck;
    private float _groundDistance = 0.05f;

    int jumpHash = Animator.StringToHash("Jump");
    int isGroundedHash = Animator.StringToHash("IsGrounded");
   

    private void Awake()
    {
        _groundCheck = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        _velocity.Set(0,0,0);
        gravity = Physics.gravity.y;
        
    }
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);    //Creating sphere to check if character is grounded

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
            _animator.SetBool(isGroundedHash, true);
        }
        else
        {
            _animator.SetBool(isGroundedHash, false);
        }

        _velocity.y += gravity * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }
    public void Jump()
    {
        if (Time.time >= _jumpTime && isGrounded)
        {
            StartCoroutine(OnJump()); //start jump after jump animation
            _jumpTime = Time.time + 1f / _jumpRate;
        }
        if (isGrounded)
        {
            
        }
    }

    IEnumerator OnJump()
    {               
        _animator.SetTrigger(jumpHash);                       //Setting False in Animation Behaviour
        yield return new WaitForSeconds(_jumpAnimationDelay);
        _velocity.y = Mathf.Sqrt(_height * -2f * gravity);
  
    }

}
