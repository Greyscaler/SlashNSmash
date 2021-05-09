using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour, IPrimaryAttack
{
    private Animator _animator;
    int attackHash = Animator.StringToHash("IsPrimaryAttack");

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 1f;
    [SerializeField] private float _primaryAttackAnimationDelay = 0.5f;
    [SerializeField] private float _attackRate = 1f;
    private float _attackTime = 0f;
    
    private int _attackForce = 10;

    public int AttackForce { get => _attackForce; set => _attackForce = value; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    void IPrimaryAttack.PrimaryAttack()
    {
        if (Time.time >= _attackTime)
        {
            StartCoroutine(Attack());
            _attackTime = Time.time + 1f / _attackRate;
        }
        
    }

    IEnumerator Attack()
    {
        _animator.SetBool(attackHash,true);

        if (_animator.GetBool("IsJumping") == true)
        {
            _primaryAttackAnimationDelay = 0.7f;
        }
        else if (_animator.GetBool("IsWalking") == true && _animator.GetBool("IsJumping") == false)
        {
            _primaryAttackAnimationDelay = 0.175f;
        }
        else if (_animator.GetBool("IsWalking") == false && _animator.GetBool("IsJumping") == false)
        {
            _primaryAttackAnimationDelay = 0.226f;
        }

        
        yield return new WaitForSeconds(_primaryAttackAnimationDelay);
        Collider[] enemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayer);

        foreach (Collider enemy in enemies)
        {
            Debug.Log(enemy.name + " Hit on " + _attackForce + " Damage");
            enemy.GetComponent<Character>().RecieveDamage(_attackForce);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position,_attackRange);
    }
}
