using UnityEngine;
using UnityEngine.UI;
using System;

public class ButtonController : MonoBehaviour
{
    public SpriteChanger spriteChanger;
    private SpriteRenderer m_SpriteRenderer;
    public Sprite[] spriteArray;
    private Sprite currentSprite;
    
    // For Character Creation
    private int currentIndex, skillPoints;

    // Reference to char stats
    public CharacterStats characterStats;

    private void Start()
    {
        // get reference to character stats script in scene
        characterStats = FindObjectOfType<CharacterStats>();
    }   

    public void OnLeftButtonClick()
    {
        currentIndex--;
        if (currentIndex < 0)
        {
            currentIndex = spriteArray.Length - 1;
        }
        spriteChanger.ChangeSprite(spriteArray[currentIndex]);
    }

    public void OnRightButtonClick()
    {
        currentIndex++;
        if (currentIndex >= spriteArray.Length)
        {
            currentIndex = 0;
        }
        spriteChanger.ChangeSprite(spriteArray[currentIndex]);
    }

    public void UsePoints()
    {
        if (currentIndex >= spriteArray.Length || characterStats.CurrentPoints <= 0)
        {
            currentIndex = currentIndex;
            characterStats.CurrentPoints = 0;
        }

        else
        {
            // Update skillPoints variable to reflect changes made in CharacterStats script

            currentIndex++; // Add points to the skill
            characterStats.CurrentPoints--;
            spriteChanger.ChangeSprite(spriteArray[currentIndex]);
        }
    }

    public void MinusPoints()
    {

        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        
        else if (characterStats.CurrentPoints < characterStats.MaxPoints)
        {
            currentIndex--;
            characterStats.CurrentPoints++;
            spriteChanger.ChangeSprite(spriteArray[currentIndex]);
        }
    }

    public void PointCounter()
    {
        currentIndex++;
        if (currentIndex > 0)
        {
            spriteChanger.ChangeSprite(spriteArray[currentIndex]);
        }
            
    }

}