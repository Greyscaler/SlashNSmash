using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    protected Animator _animator;
    private Character _character;

    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 1f;

    private float _primaryAttackAnimationDelay = 0.5f;

    private int attackHash;
    protected int AttackHash { get => attackHash; set => attackHash = value; }

    private LayerMask _enemyLayerMask;

    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
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
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);              //Draw WireSphere in the viewport of the editor
    }

    public void CheckForCollision()
    {
        StartCoroutine(PerformAttack());
    }

    protected virtual float AttackAnimationDelay(Animator animator)
    {
        return 0;
    }

    protected virtual void ApplyDamage(Collider enemy)
    {
    }

    IEnumerator PerformAttack()
    {

        _primaryAttackAnimationDelay = AttackAnimationDelay(_animator);
        yield return new WaitForSeconds(_primaryAttackAnimationDelay);
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);   //collision point testing
        //sphere.transform.position = _attackPoint.position;

        //Debug.Log(LayerMask.LayerToName((int)Mathf.Log(_enemyLayerMask.value, 2)));      // Mathf.Log... dirty way to get layermask where is a single layer

        Collider[] enemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayerMask);       //Get Array of colliders which intersected OverlapSphere

        foreach (Collider enemy in enemies)
        {
            Debug.Log(enemy.name + " Hit on " + AttackForce + " Damage");
            ApplyDamage(enemy);
        }
    }
}
