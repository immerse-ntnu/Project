using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D body;
    private float _horizontal;
    private float _vertical;
    [SerializeField] private float walkSpeed;

    // For attacking enemy
    public float attackRange = 1f; // the range of the player's attack
    public int attackDamage = 50; // the damage the player's attack will do
    private GameObject enemy;
    private EnemyHealth _enemyHealth;

    private void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        _enemyHealth = enemy.GetComponent<EnemyHealth>();
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            _horizontal = Input.GetAxisRaw("Horizontal");
            _vertical = Input.GetAxisRaw("Vertical");
        }

        // Only if enemy is alive
 
        if (enemy == null) return;
        var position = enemy.transform.position;
        var enemyPos = new Vector3(position.x, position.y, position.z);

        // Attack
        if (!Input.GetKeyDown(KeyCode.Space)) return;
        if (Vector3.Distance(transform.position, enemy.transform.position) > attackRange) return;
        _enemyHealth.TakeDamage(attackDamage);
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
