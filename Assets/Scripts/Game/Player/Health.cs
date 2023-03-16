using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar Healthbar;
    public Image deathImage;

    private SpriteRenderer sprite;
    
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetMaxHealth(maxHealth);
        deathImage.gameObject.SetActive(false);

        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }

        if (currentHealth == 0)
        {
            // play death animation
            StartCoroutine(Die());
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth);
        StartCoroutine(FlashRed());
    }

    private IEnumerator Die()
    {
        // spawn loot prefab
        deathImage.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        GameController.DestroyAllGameObjects();
        GameLoader.LoadMainMenu();
        gameObject.SetActive(false);
    }
    
    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f); // wait for half a second
        sprite.color = Color.white;
    }
    
}
