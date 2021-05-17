using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttack : MeleeAttack, ISecondaryAttack
{
    [SerializeField] private float _knockbackForce = 10f;
    private void Awake()
    {
        AttackHash = Animator.StringToHash("SecondaryAttack");
    }
    override protected float AttackAnimationDelay(Animator animator)
    {
        return 0.5f;
    }

    protected override void ApplyDamage(Collider enemy)
    {
        enemy.GetComponent<Character>().RecieveDamage(AttackForce);
        KnockBack(enemy);
    }

    private void KnockBack(Collider enemy)
    {
        Imovable _enemyMovement = enemy.GetComponent<Imovable>();
        Imovable _playerMovement = GetComponent<Imovable>();
        float speedboost = 0f;

        if(_animator.GetBool("IsWalking"))
        {
            speedboost = _playerMovement.MaxSpeed.x;
        }

        if (transform.position.x > enemy.transform.position.x)
        {
            _enemyMovement.Speed = new Vector3(-_knockbackForce -speedboost, 0, 0);
        }
        else
        {
            _enemyMovement.Speed = new Vector3(_knockbackForce + speedboost, 0, 0);
        }

    }
}
