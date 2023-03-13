using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    // For being attacked:
    public int maxHealth = 100; // the maximum health of the enemy
    public int currentHealth; // the current health of the enemy
    

    private void Start()
    {
        currentHealth = maxHealth;
    }


    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(int damage)
    {
        // subtract the damage from the enemy's current health
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            Debug.Log("Health: " + currentHealth);
        }
        
        // check if the enemy has died
        if (currentHealth > 0) return;
        gameObject.SetActive(false); // die
        Destroy(gameObject, 3);
    }
}