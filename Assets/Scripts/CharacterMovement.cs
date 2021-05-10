using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, Imovable
{
    
    [SerializeField] private float _acceleration = 0.1f;
    [SerializeField] private float _smoothTime = 1.0f;
    [SerializeField] private float _maxSpeed = 10f;

    private float _speed = 0f;
    private Vector3 _direction;
    private float _prevDirection;
    private Vector3 _rotationDirection;
    private CharacterController _characterController;
    private Transform _transform;
    private float turnVelocity;

    private Animator _animator;
    private bool isWalking= false;
    int isWalkingHash = Animator.StringToHash("IsWalking");

    public float Speed {get => _speed;set => _speed = value;}
    public Vector3 Direction { get => _direction; set => _direction = value.normalized; }

    private ICrouch _crouchCharacter;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rotationDirection = new Vector3(1,0,0);
    }

    private void Update()
    {
        
        
        Move();
        Rotate();
        _animator.SetFloat("Speed", Mathf.Abs(_speed)/_maxSpeed);
        _animator.SetBool(isWalkingHash, isWalking);
    }
    public void SetTranslate(Vector3 direction)
    {
        Direction = direction;
        
        
        if (Mathf.Abs(_direction.x) >= 0.1f)
        {
            _rotationDirection = _direction;
        }
    }


    public void SetRotate(Vector3 direction)
    {
        


    }
    

    private void Move()
    {
        if (_direction.x == 0)
        {
            if (_speed > 0)
            {
                _speed -= _acceleration;
                _speed = Mathf.Clamp(_speed, 0, _maxSpeed);
            }
            else if (_speed < 0)
            {

                _speed += _acceleration;
                _speed = Mathf.Clamp(_speed, -_maxSpeed, 0);
            }
            isWalking = false;
        }
        else
        {
            if (_direction.x > 0)
            {
                _speed += _acceleration;

            }
            else
            {
                _speed -= _acceleration;
            }
            _speed = Mathf.Clamp(_speed, -_maxSpeed, _maxSpeed);
            isWalking = true;
        }
        _characterController.Move(new Vector3(_speed, 0, 0) * Time.deltaTime);


    }

    private void Rotate()
    {
        float targetAngle = Mathf.Atan2(_rotationDirection.x, 0) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref turnVelocity, _smoothTime);
        _transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
