using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCrouch : MonoBehaviour, ICrouch
{
    private Animator _animator;
    int crouchHash = Animator.StringToHash("IsCrouching");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void Crouch(bool value)
    {
        _animator.SetBool(crouchHash,value);
    }

    
}
