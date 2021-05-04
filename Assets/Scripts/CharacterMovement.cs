using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, Imovable
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _smoothTime = 1.0f;
    
    private float _direction;
    private CharacterController _characterController;
    private Transform _transform;
    private float turnVelocity;
    private Animator _animator;
    private bool isWalking= false;
    int isWalkingHash = Animator.StringToHash("IsWalking");

    public float Speed {get => _speed;set => _speed = value;}
    public float Direction { get => _direction; set => _direction = value; }


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }
    public void Translate(float direction)
    {
        Direction = direction;
        _characterController.Move(new Vector3(_direction, 0, 0).normalized * _speed * Time.deltaTime);
        if (_direction != 0f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }
        _animator.SetBool(isWalkingHash,isWalking);
        
    }

    public void Rotate(float direction)
    {
        Direction = direction;
        if (Mathf.Abs(_direction) >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction, 0) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref turnVelocity, _smoothTime);
            _transform.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
