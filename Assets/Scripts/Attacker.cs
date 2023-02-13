using UnityEngine;

public class Attacker : MonoBehaviour
{
    private Animator _anim;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Damager(int damageAmt)
    {
        Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange);
        foreach (var health in damage) 
        {
            if (health.TryGetComponent(out UnitHealth unitHealth) && unitHealth.gameObject != gameObject)
            {
                print(unitHealth);
                unitHealth.Damage(damageAmt);
                // anim.SetBool("attacked", true);
            }
        }
    }
    
    private void Update()
    {

        // iPhone if you touch on certain parts of the screen
        var touch = Input.touches[0];
        
        int DmgAmt = Random.Range(1, 5);

        Damager(DmgAmt);
    }
}