// A simple health controller for a player in Unity
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    private int _maxHealth, _minHealth, _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth; // Start with giving player max health
    }

    private void KillPlayer()
    {
        Destroy(gameObject);
    }

    public void Damage(int dmgAmt)
    {
        _currentHealth -= dmgAmt;
        if (_currentHealth < _minHealth)
        {
            KillPlayer(); // destroys the object
        }
    }

}
