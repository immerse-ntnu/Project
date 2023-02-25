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
            // Update skillPoints variable to reflect changes made in CharacterStats script
        if (characterStats.CurrentPoints > 0)
            {
                currentIndex++; // Add points to specific skill
                characterStats.CurrentPoints--; // Remove skillpoints
                if (currentIndex < spriteArray.Length)
                {
                    spriteChanger.ChangeSprite(spriteArray[currentIndex]);
                }
                else
                {
                    currentIndex = spriteArray.Length;
                    spriteChanger.ChangeSprite(spriteArray[currentIndex]);
                }
            }
    }

    public void MinusPoints()
    {

        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        
        else if (characterStats.CurrentPoints < characterStats.MaxPoints 
        && characterStats.CurrentPoints >= 0 && currentIndex > 0)
        {
            currentIndex--;
            characterStats.CurrentPoints++;
            spriteChanger.ChangeSprite(spriteArray[currentIndex]);
        }
    }

    public void PointCounter()
    {
        spriteChanger.ChangeSprite(spriteArray[characterStats.CurrentPoints]);    
    }


    
    public void AddAttack()
    {
        if (characterStats.CurrentPoints > 0)
        {
            characterStats.AttackLevel++;
        }
    }

    public void AddDefence()
    {
        if (characterStats.CurrentPoints > 0)
        {
            characterStats.DefenceLevel++;
        }
    }

    public void AddStrength()
    {
        if (characterStats.CurrentPoints > 0)
        {
            characterStats.StengthLevel++;
        }
    }

    public void AddStamina()
    {
        if (characterStats.CurrentPoints > 0)
        {
            characterStats.StaminaLevel++;
        }
    }

    public void SubtractAttack()
    {
        if (characterStats.AttackLevel > 1)
        {
            characterStats.AttackLevel--;
        }
    }

    public void SubtractDefence()
    {
        if (characterStats.DefenceLevel > 1)
        {
            characterStats.DefenceLevel--;
        }
    }

    public void SubtractStrength()
    {
        if (characterStats.StengthLevel > 1)
        {
            characterStats.StengthLevel--;
        }
    }

    public void SubtractStamina()
    {
        if (characterStats.StaminaLevel > 1)
        {
            characterStats.StaminaLevel--;

        }
    }
}

