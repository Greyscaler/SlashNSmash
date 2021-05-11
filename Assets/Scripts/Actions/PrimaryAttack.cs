using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : Attack, IPrimaryAttack
{
    private Animator _animator;
    private Character _character;
    
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 1f;
    
    private float _primaryAttackAnimationDelay = 0.5f;

    int attackHash = Animator.StringToHash("PrimaryAttack");
    int isGroundedHash = Animator.StringToHash("IsGrounded");
    int isWalkingHash = Animator.StringToHash("IsWalking");
    int isCrouchingHash = Animator.StringToHash("IsCrouching");

    private LayerMask _enemyLayerMask;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
    }
    private void Start()
    {
        _enemyLayerMask = LayerMask.GetMask(LayerMask.LayerToName(_character.EnemyLayer));   //Get LayerMask from Layer Number
    }

    public void Attack()
    {
        if (Time.time >= AttackTime)
        {
            _animator.SetTrigger(attackHash);
            AttackTime = Time.time + 1f / AttackRate;
        }
    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position,_attackRange);              //Draw WireSphere in the viewport of the editor
    }

    public void CheckForCollision()
    {
        StartCoroutine(PerformAttack());
    }
    IEnumerator PerformAttack()
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

        //Debug.Log(LayerMask.LayerToName((int)Mathf.Log(_enemyLayerMask.value, 2)));      // Mathf.Log... dirty way to get layermask where is a single layer
        
        Collider[] enemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayerMask);       //Get Array of colliders which intersected OverlapSphere


        foreach (Collider enemy in enemies)
        {
            Debug.Log(enemy.name + " Hit on " + AttackForce + " Damage");
            enemy.GetComponent<Character>().RecieveDamage(AttackForce);
        }
    }
}
