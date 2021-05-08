using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    private float _direction;

    Imovable moveCharacter;
    IJump jumpCharacter;
    IPrimaryAttack primaryAttack;

    private Animator _animator;
    private int dieHash = Animator.StringToHash("IsDead");
    private int onHit = Animator.StringToHash("Hit");

    private int _health = 30;
    private int _maxHealth = 100;

    public int Health { get => _health; set =>_health = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    private Collider _collider;

    private void Awake()
    {
        moveCharacter = GetComponent<Imovable>();
        jumpCharacter = GetComponent<IJump>();
        primaryAttack = GetComponent<IPrimaryAttack>();
        _animator = GetComponent<Animator>();
        _collider = GetComponent<Collider>();
    }

    public void Move(Vector3 direction)
    {
        moveCharacter.SetTranslate(direction);
    }

    public void Jump()
    {
        jumpCharacter.Jump();
    }

    public void PrimaryAttack()
    {
        primaryAttack.PrimaryAttack();
    }

    public void RecieveDamage(int value)
    {
        Health -= value;
        if (_health <= 0)
        {
            Die();
        }
        else
        {
            _animator.SetTrigger(onHit);
        }
    }

    public void GetProne()
    { 
        
    }

    private void Die()
    {
        _animator.SetBool(dieHash,true);
        _collider.enabled = false;
        Debug.Log(this.name + " is Dead");
        //this.enabled = false;

    }
}
