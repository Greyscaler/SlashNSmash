using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, Imovable
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _smoothTime = 1.0f;
    
    private Vector3 _direction;
    private Vector3 _rotationDirection;
    private CharacterController _characterController;
    private Transform _transform;
    private float turnVelocity;

    private Animator _animator;
    private bool isWalking= false;
    int isWalkingHash = Animator.StringToHash("IsWalking");

    public float Speed {get => _speed;set => _speed = value;}
    public Vector3 Direction { get => _direction; set => _direction = value.normalized; }


    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rotationDirection = new Vector3(1,0,0);
    }

    private void FixedUpdate()
    {
        _characterController.Move(_direction * _speed * Time.deltaTime);
        if (_direction.x != 0f)
        {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

       float targetAngle = Mathf.Atan2(_rotationDirection.x, 0) * Mathf.Rad2Deg;
       float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref turnVelocity, _smoothTime);
       _transform.rotation = Quaternion.Euler(0, angle, 0);
        

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
}
