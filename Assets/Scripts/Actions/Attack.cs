using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float _attackRate = 1f;
    [SerializeField] private int _attackForce = 10;
    private float _attackTime = 0f;

    protected float AttackRate { get => _attackRate; set => _attackRate = value; }
    protected float AttackTime { get => _attackTime; set => _attackTime = value; }
    protected int AttackForce { get => _attackForce; set => _attackForce = value; }
    
    
}
