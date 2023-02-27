using UnityEngine;
using System;
/*
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
        currentIndex = 0;
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
        Debug.Log("Attack: " + characterStats.AttackLevel);
        // Update skillPoints variable to reflect changes made in CharacterStats script
        if (characterStats.CurrentPoints > 0 && currentIndex < spriteArray.Length)
        {
            characterStats.CurrentPoints--; // Remove skill points
            currentIndex++; // Add points to specific skill
            spriteChanger.ChangeSprite(spriteArray[currentIndex]);
        }
    }

    public void MinusPoints()
    {

        if (currentIndex < 0)
        {
            currentIndex = 0;
        }
        
        else if (characterStats.CurrentPoints < characterStats.MaxPoints 
        && characterStats.CurrentPoints > 0 && currentIndex > 0)
        {
            currentIndex--;
            characterStats.CurrentPoints++;
            spriteChanger.ChangeSprite(spriteArray[0]);
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
            characterStats.StrengthLevel++;
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
        if (characterStats.StrengthLevel > 1)
        {
            characterStats.StrengthLevel--;
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

*/