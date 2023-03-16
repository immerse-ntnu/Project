using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    // For walking
    public Rigidbody2D body;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float walkSpeed;
    private int defaultWalk = 5;
    private int runSpeed = 10;
    [SerializeField] private SpriteRenderer sprite;
    private Animator _anim;
    
    // For attacking enemy
    public float attackRange = 1f; // the range of the player's attack
    public int attackDamage = 50; // the damage the player's attack will do
    private readonly int _enemyLayerMask = 1 << 3;
    private readonly Collider2D[] _enemies = new Collider2D[6];

    // For animation
    private Animator _mAnimator;
    private bool _ismAnimatorNotNull;

    private void Start()
    {
        
        body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ReSharper disable once HeapView.ObjectAllocation
            StartCoroutine(Attack());
        }

        sprite.flipX = _horizontal switch
        {
            < 0 => false,
            > 0 => true,
            _ => sprite.flipX
        };

        _anim.SetBool("isMoving", new Vector2(_horizontal, _vertical).magnitude > 0);
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            walkSpeed = runSpeed;
            _anim.speed = 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = defaultWalk;
            _anim.speed = 1;
        }
    }

    public IEnumerator Attack()
    {
        _anim.SetBool("isAttacking", true);
        var size = Physics2D.OverlapCircleNonAlloc(transform.position, attackRange, _enemies, _enemyLayerMask);
        for (var i = 0; i < size; i++)
            if (_enemies[i].TryGetComponent(out EnemyHealth health))
                health.TakeDamage(attackDamage);
        
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        yield return new WaitForSeconds(0.5f);
        _anim.SetBool("isAttacking", false);
    }

    private void FixedUpdate()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            body.velocity = new Vector2(_horizontal * walkSpeed, _vertical * walkSpeed);
        }
    }
    
    // visualize the attack range in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
