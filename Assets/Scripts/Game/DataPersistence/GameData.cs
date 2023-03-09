using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    protected int CurrentPoints;
    protected string Name;
    public List<Sprite> appearance;
    public Dictionary<string, int> SavedSkill = new() {
        { "Attack", 1 },
        { "Strength", 1 },
        { "Defence", 1 },
        { "Magic", 1 },
        { "Ranged", 1 },
        { "Agility", 1 },
        { "Charisma", 1},
        { "HealthPoints", 10}
    };

        // Constructor
    public GameData()
    {
        // Current points
        CurrentPoints = 9;
        
        // Character name
        Name = "Character Name";
        
        // Character skill levels as dictionary
        var savedSkill = new Dictionary<string, int>()
        {
            { "Attack", 1 },
            { "Strength", 1 },
            { "Defence", 1 },
            { "Magic", 1 },
            { "Ranged", 1 },
            { "Agility", 1 },
            { "Charisma", 1},
            { "HealthPoints", 10}
        };
    
    } 
}
