using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int attack, strength, defence, stamina; // Skills
    [SerializeField] private int currentPoints, skillPoints, maxPoints;
    
    // Global max points player can hold
    public int MaxPoints
    {
        get { return maxPoints; }
    }

    // Global current skill points
    public int CurrentPoints
    {
        get => currentPoints;
        set => currentPoints = value;
    }
    
    // Player Attack Level
    public int AttackLevel
    {
        get => attack;
        set => attack = value;
    }

    public int StrengthLevel
    {
        get => strength;
        set => strength = value;
    }

    public int DefenceLevel
    {
        get => defence;
        set => defence = value;
    }

    public int StaminaLevel
    {
        get => stamina;
        set => stamina = value;
    }

    void Start()
    {
        // Start with level 1 in everything
        attack = 1;
        strength = 1;
        defence = 1;
        stamina = 1;

        maxPoints = 13; // In the start, the player has 13 max points
        skillPoints = maxPoints - (attack + strength + defence + stamina);
        currentPoints = skillPoints;
    }

    void Update()
    {
        attack = AttackLevel;
        strength = StrengthLevel;
        defence = DefenceLevel;
        stamina = StaminaLevel;

        skillPoints = maxPoints - (attack + strength + defence + stamina);
        currentPoints = skillPoints;
    }
}
