using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultJump : MonoBehaviour, IJump
{
    [SerializeField] private float _height;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private float _jumpAnimationDelay = 0.15f;

    
    private CharacterController _characterController;
    private Vector3 _velocity;
    private float gravity;
    private Animator _animator;


    private bool isGrounded = false;
    private Transform _groundCheck;
    private float _groundDistance = 0.1f;

    
   

    private void Awake()
    {
        _groundCheck = GetComponent<Transform>();
        _characterController = GetComponent<CharacterController>();
        _velocity.Set(0,0,0);
        gravity = Physics.gravity.y;
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        isGrounded = Physics.CheckSphere(_groundCheck.position,_groundDistance,_groundMask);

        if (isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        _velocity.y += gravity * Time.deltaTime;
        
        _characterController.Move(_velocity * Time.deltaTime);
    }
    public void Jump()
    {
        _animator.SetTrigger("Jump");
        StartCoroutine(waiter());
        
    }

    IEnumerator waiter()
    {       
        yield return new WaitForSeconds(_jumpAnimationDelay);
        if (isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_height * -2f * gravity);
        }

    }

}
