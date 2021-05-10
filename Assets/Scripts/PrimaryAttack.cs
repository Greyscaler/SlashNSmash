using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour, IPrimaryAttack
{
    private Animator _animator;
    

    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 1f;
    private float _primaryAttackAnimationDelay = 0.5f;
    [SerializeField] private float _attackRate = 1f;
    private float _attackTime = 0f;
    
    private int _attackForce = 10;

    public int AttackForce { get => _attackForce; set => _attackForce = value; }

    int attackHash = Animator.StringToHash("PrimaryAttack");
    int isGroundedHash = Animator.StringToHash("IsGrounded");
    int isWalkingHash = Animator.StringToHash("IsWalking");
    int isCrouchingHash = Animator.StringToHash("IsCrouching");

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    void IPrimaryAttack.PrimaryAttack()
    {
        if (Time.time >= _attackTime)
        {
            _animator.SetTrigger(attackHash);
            _attackTime = Time.time + 1f / _attackRate;
        }
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position,_attackRange);
    }

    public void CheckForCollision()
    {
        StartCoroutine(Attack());
    }
    IEnumerator Attack()
    {
        if (_animator.GetBool(isCrouchingHash) == true)
        {
            _animator.SetLayerWeight(1, 1);
            _primaryAttackAnimationDelay = 0.61f;
            
        }
        else
        {
            _animator.SetLayerWeight(1, 0);
        }


        if (_animator.GetBool(isGroundedHash) == false)
        {
            _primaryAttackAnimationDelay = 0.8f;
        }
        else if (_animator.GetBool(isWalkingHash) == true && _animator.GetBool(isGroundedHash) == true && _animator.GetBool(isCrouchingHash) == false)
        {
            _primaryAttackAnimationDelay = 1.13f;
        }
        else if (_animator.GetBool(isWalkingHash) == false && _animator.GetBool(isGroundedHash) == true && _animator.GetBool(isCrouchingHash) == false)
        {
            _primaryAttackAnimationDelay = 0.665f;
        }
        
        yield return new WaitForSeconds(_primaryAttackAnimationDelay);
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);   //collision point testing
        //sphere.transform.position = _attackPoint.position;
        Collider[] enemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayer);


        foreach (Collider enemy in enemies)
        {
            Debug.Log(enemy.name + " Hit on " + _attackForce + " Damage");
            enemy.GetComponent<Character>().RecieveDamage(_attackForce);
        }
    }
}
