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
    public GameObject lootPrefab;
    private SpriteRenderer sprite;
    
    private void Start()
    {
        currentHealth = maxHealth;
        sprite = GetComponent<SpriteRenderer>();
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public void TakeDamage(int damage)
    {
        // subtract the damage from the enemy's current health
        if (currentHealth > 0)
        {
            currentHealth -= damage;
            StartCoroutine(FlashRed());
        }
        
        // check if the enemy has died
        if (currentHealth > 0) return;
        StartCoroutine(Die());
    }
    
    private IEnumerator Die()
    {
        // spawn loot prefab
        sprite.color = Color.black;
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        Destroy(gameObject, 2f);
        Instantiate(lootPrefab, transform.position, Quaternion.identity);
    }
    
    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f); // wait for half a second
        sprite.color = Color.white;
    }
    
    
    
}