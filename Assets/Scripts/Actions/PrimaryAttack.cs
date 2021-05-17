using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryAttack : MeleeAttack, IPrimaryAttack
{
    int isGroundedHash = Animator.StringToHash("IsGrounded");
    int isWalkingHash = Animator.StringToHash("IsWalking");
    int isCrouchingHash = Animator.StringToHash("IsCrouching");


    private void Awake()
    {
        AttackHash = Animator.StringToHash("PrimaryAttack");
    }
    override protected float AttackAnimationDelay(Animator animator)
    {   
        if (animator.GetBool(isCrouchingHash) == true)
        {
            animator.SetLayerWeight(1, 1);
            return 0.61f;

        }
        else
        {
            _animator.SetLayerWeight(1, 0);
        }


        if (_animator.GetBool(isGroundedHash) == false)
        {
            return 0.8f;
        }
        else if (_animator.GetBool(isWalkingHash) == true && _animator.GetBool(isGroundedHash) == true && _animator.GetBool(isCrouchingHash) == false)
        {
            return 1.13f;
        }
        else if (_animator.GetBool(isWalkingHash) == false && _animator.GetBool(isGroundedHash) == true && _animator.GetBool(isCrouchingHash) == false)
        {
            return 0.665f;
        }
        return 0;
    }

    protected override void ApplyDamage(Collider enemy)
    {
        enemy.GetComponent<Character>().RecieveDamage(AttackForce);
    }
}
