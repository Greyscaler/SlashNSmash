using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour, IDamageable
{
    Imovable moveCharacter;
    IJump jumpCharacter;
    IPrimaryAttack primaryAttack;
    ISecondaryAttack secondaryAttack;
    ICrouch crouchCharacter;

    private Animator _animator;
    private int _enemyLayer;
    private int dieHash = Animator.StringToHash("IsDead");
    private int onHit = Animator.StringToHash("Hit");
    private bool _movementEnabled = true;
    private bool _attackEnabled = true;
   
    private int _health;
    private int _maxHealth = 100;

    public int EnemyLayer => _enemyLayer;
    public int Health { get => _health; set =>_health = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

    public bool MovementEnabled { get => _movementEnabled; set => _movementEnabled = value; }
    public bool AttackEnabled { get => _attackEnabled; set => _attackEnabled = value; }



    [System.Serializable]
    public class HealthEvent : UnityEvent<int> { }
    public HealthEvent OnHealthChange;

    private void Awake()
    {
        gameObject.layer = transform.parent.gameObject.layer;
        GameManager gameManager = transform.parent.parent.GetComponent<GameManager>();
        _enemyLayer = GetEnemyLayer(gameManager.Layers, gameObject.layer);
        moveCharacter = GetComponent<Imovable>();
        jumpCharacter = GetComponent<IJump>();
        primaryAttack = GetComponent<IPrimaryAttack>();
        secondaryAttack = GetComponent<ISecondaryAttack>();
        crouchCharacter = GetComponent<ICrouch>();
        _animator = GetComponent<Animator>();
        OnHealthChange = new HealthEvent();
    }

    private void Start()
    {
        Health = MaxHealth;
    }

    private int GetEnemyLayer(int[] layers, int playerLayer)
    {   
        foreach (int layer in layers)
        {
            if (layer != playerLayer)
            {
                return layer;
            }
        }
        return 0;
    }

    public void Move(Vector3 direction)
    {
        if (_movementEnabled)
        {
            moveCharacter.SetTranslate(direction);
        }
    }

    public void Jump()
    {
        if (_movementEnabled)
        {
            jumpCharacter.Jump();
        }
    }

    public void PrimaryAttack()
    {
        if (_attackEnabled)
        {
            primaryAttack.Attack();
        }
    }
    public void SecondaryAttack()
    {
        if (_attackEnabled)
        {
            secondaryAttack.Attack();
        }
    }

    public void RecieveDamage(int value)
    {
        Health -= value;
        _animator.SetTrigger(onHit);
        if (_health <= 0)
        {
            Die();
        }
        OnHealthChange.Invoke(Health);
    }

    public void Crouch(bool value)
    {
        if (_movementEnabled)
        {
            crouchCharacter.Crouch(value);
        }
    }
    public void GetProne()
    { 
        
    }

    private void Die()
    {
        _animator.SetBool(dieHash,true);
        //_collider.enabled = false;
        Debug.Log(this.name + " is Dead");
        //this.enabled = false;

    }
}
