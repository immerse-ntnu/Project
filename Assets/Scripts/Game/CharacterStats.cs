using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [SerializeField] private int attack, strength, defence, stamina; // Skills
    [SerializeField] private int currentPoints, skillPoints, maxPoints;

    public int MaxPoints
    {
        get { return maxPoints; }
    }

    public int CurrentPoints
    {
        get { return currentPoints; }
        set { 
            currentPoints = value;
            skillPoints = currentPoints;
            }
    }

    void Start()
    {
        attack = 1;
        strength = 1;
        defence = 1;
        stamina = 1;
        maxPoints = 13;
        skillPoints = maxPoints - (attack + strength + defence + stamina);
        currentPoints = skillPoints;
    }

    void Update()
    {
        skillPoints = maxPoints - (attack + strength + defence + stamina);
    }
}
