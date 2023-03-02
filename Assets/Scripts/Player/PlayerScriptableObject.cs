using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    public int health = 100;
    public int armour = 100;
    public float balance = 250f;
    public PlayerAttackScriptableObject playerAttackType;
    
}

// private void Awake()
// {
//     Debug.Log("Awake");
// }
//
// private void OnEnable()
// {
//     Debug.Log("OnEnable");
// }
//
// private void OnDisable()
// {
//     Debug.Log("OnDisable");
// }
//
// private void OnDestroy()
// {
//     Debug.Log("OnDestroy");
// }
//
// private void OnValidate()
// {
//     Debug.Log("OnValidate");
// }

