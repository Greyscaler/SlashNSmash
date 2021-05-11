using UnityEngine;

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
   
    private int _health = 30;
    private int _maxHealth = 100;

    public int EnemyLayer => _enemyLayer;
    public int Health { get => _health; set =>_health = value; }
    public int MaxHealth { get => _maxHealth; set => _maxHealth = value; }

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
        moveCharacter.SetTranslate(direction);
    }

    public void Jump()
    {
        jumpCharacter.Jump();
    }

    public void PrimaryAttack()
    {
        primaryAttack.Attack();
    }
    public void SecondaryAttack()
    {
        secondaryAttack.Attack();
    }

    public void RecieveDamage(int value)
    {
        Health -= value;
        _animator.SetTrigger(onHit);
        if (_health <= 0)
        {
            Die();
        }
    }

    public void Crouch(bool value)
    {
        crouchCharacter.Crouch(value);
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
