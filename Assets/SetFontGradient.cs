using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetFontGradient : StateMachineBehaviour
{
    public TMP_ColorGradient gradient;
    private TMP_Text text;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        text = animator.GetComponentInChildren<TMP_Text>(); 
        text.colorGradientPreset = gradient;
    }

  
}
