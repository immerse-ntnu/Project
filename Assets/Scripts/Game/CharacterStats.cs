using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int attack, strength, defence, stamina; // Skills
    [SerializeField] private int currentPoints, skillPoints, maxPoints;

    Dictionary<string, int> Skills = new Dictionary<string, int>();
    
    // Global max points player can hold
    public int MaxPoints
    {
        get { return maxPoints; }
    }

    // Global current skillpoints
    public int CurrentPoints
    {
        get { return currentPoints; }
        set { 
            currentPoints = value;
            skillPoints = currentPoints;
            }
    }

    // Player Attack Level
    public int AttackLevel
    {
        get {return attack;}
        set {attack = value;}
    }

    public int StengthLevel
    {
        get {return strength;}
        set {strength = value;}
    }

    public int DefenceLevel
    {
        get {return defence;}
        set {defence = value;}
    }

    public int StaminaLevel
    {
        get {return stamina;}
        set {stamina = value;}
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
        skillPoints = maxPoints - (attack + strength + defence + stamina);

    }
}
