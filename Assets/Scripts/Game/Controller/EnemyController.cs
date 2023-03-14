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

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _target = GameObject.FindWithTag("Player").transform;
        health = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (!_isInAttackRange)
        {
            _anim.SetBool("isChasing", _isInChaseRange);
        }
        else if (health.currentHealth <= 0) // if enemy is dead
        {
            _anim.SetBool("isDead", true);
        }
        else
        {
            _anim.SetBool("attacking", _isInAttackRange);
        }

        var position1 = transform.position;
        _isInChaseRange = Physics2D.OverlapCircle(position1, checkRadius, whatIsPlayer.value);
        _isInAttackRange = Physics2D.OverlapCircle(position1, attackRadius, whatIsPlayer.value);

        dir = _target.position - position1;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        _movement = dir;
        
        if (!shouldRotate) return;
        _anim.SetFloat("X", dir.x);
        _anim.SetFloat("Y", dir.y);

    }
    
    private void FixedUpdate()
    {
        if (_isInChaseRange && !_isInAttackRange && health.currentHealth > 0)
        {
            MoveCharacter(_movement);
        }

        if (_isInAttackRange) // stop moving once in attack range
        {
            _rb.velocity = Vector2.zero;
        }
    }

    private void MoveCharacter(Vector2 dir)
    {
        Debug.Log("MoveCharacter called");
        _rb.MovePosition((Vector2)transform.position + (dir * (speed * Time.deltaTime)));
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