using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttack : Attack //ISecondaryAttack
{
    
    
    /*
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange;
    private LayerMask _enemyLayerMask;

    private Animator _animator;
    private Character _character;
    private float _secondaryAttackAnimationDelay = 0.5f;

    int attackHash = Animator.StringToHash("SecondaryAttack");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _character = GetComponent<Character>();
    }
    private void Start()
    {
        _enemyLayerMask = LayerMask.GetMask(LayerMask.LayerToName(_character.EnemyLayer));
    }
    public void Attack()
    {
        if (Time.time >= AttackTime)
        {
            _animator.SetTrigger(attackHash);
            AttackTime = Time.time + 1f / AttackRate;
        }
    }
    public void CheckForCollision()
    {
        StartCoroutine(PerformAttack());
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);              //Draw WireSphere in the viewport of the editor
    }

    IEnumerator PerformAttack()
    {
        yield return new WaitForSeconds(_secondaryAttackAnimationDelay);
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.position = _attackPoint.position;
        Collider[] enemies = Physics.OverlapSphere(_attackPoint.position, _attackRange, _enemyLayerMask);       //Get Array of colliders which intersected OverlapSphere


        foreach (Collider enemy in enemies)
        {
            Debug.Log(enemy.name + " Hit on " + AttackForce + " Damage");
            enemy.GetComponent<Character>().RecieveDamage(AttackForce);
        }
    }*/
}
