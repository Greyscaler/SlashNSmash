using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnAnimationEnd : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("IsJumping",false);
    }

    
}