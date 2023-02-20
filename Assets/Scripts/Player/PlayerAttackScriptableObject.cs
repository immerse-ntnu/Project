using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackScriptableObject", menuName = "ScriptableObjects/PlayerAttack")]
public class PlayerAttackScriptableObject : ScriptableObject
{
    public float attackDamage = 20f;
    public float attackRange = 10f;
    public AudioClip attackSound;
}
