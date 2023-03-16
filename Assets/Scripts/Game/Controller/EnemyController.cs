using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float checkRadius;
    public float attackRadius;

    public bool shouldRotate;

    public LayerMask whatIsPlayer;

    private Transform _target;
    private Rigidbody2D _rb;
    private Animator _anim;
    private Vector2 _movement;
    public Vector3 dir;

    private bool _isInChaseRange;
    private bool _isInAttackRange;

    private EnemyHealth health;
    private Health targetHealth;
    
    private float attackCooldown = 2;
    private float attackDelay = 1;
    private float _lastAttackTime;
    private float _lastAttackStartTime;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _target = GameObject.FindWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
        targetHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
    }

    private void Update()
    {
        
        if (health.currentHealth <= 0) // if enemy is dead
        {
            _anim.SetBool("isDead", true);
        }
        else if (_isInAttackRange != true)
        {
            _anim.SetBool("isChasing", _isInChaseRange);
        }

        var position1 = transform.position;
        _isInChaseRange = Physics2D.OverlapCircle(position1, checkRadius, whatIsPlayer.value);
        _isInAttackRange = Physics2D.OverlapCircle(position1, attackRadius, whatIsPlayer.value);

        dir = _target.position - position1;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        _movement = dir;

        if (shouldRotate && health.currentHealth > 0 && _isInAttackRange != true)
        {
            _anim.SetFloat("X", dir.x);
            _anim.SetFloat("Y", dir.y); 
        }
    }
    
    private void FixedUpdate()
    {
        if (_isInChaseRange && !_isInAttackRange && health.currentHealth > 0)
        {
            MoveCharacter(_movement);
        }

        if (_isInAttackRange)
        {
            if (Time.time - _lastAttackTime >= attackCooldown)
            {
                if (Time.time - _lastAttackStartTime >= attackDelay)
                {
                    _lastAttackTime = Time.time;
                    Attack();
                }
                else
                {
                    _rb.velocity = Vector2.zero;
                    _anim.SetBool("attacking", false);
                }
            }
            else
            {
                _rb.velocity = Vector2.zero;
                _anim.SetBool("attacking", false);
            }
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        _rb.MovePosition((Vector2)transform.position + (dir * (speed * Time.deltaTime)));
    }
    
    private void Attack()
    {
        _rb.velocity = Vector2.zero;
        _anim.SetBool("attacking", true);
        targetHealth.TakeDamage(10);
        
    }
    
    // Visualize radius in inspector unity 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, checkRadius);
        Gizmos.DrawWireSphere(position, attackRadius);
    }
}