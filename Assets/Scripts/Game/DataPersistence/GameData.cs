using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    protected int CurrentPoints; // Current skill points
    
    public string Name; // Name of player

    public Vector3 sizeOfPlayer; // Size of player
    
    // public List<Sprite> appearance; // Player sprite array appearance

    public Dictionary<Attributes.SkillType, int> Skills;

    public int gems;

    // Constructor
    public GameData()
    {
        // Current points
        CurrentPoints = 9;
        
        // Character name
        Name = "Character Name";
        
        // Character skill levels as dictionary
        Skills = new Dictionary<Attributes.SkillType, int>()
        {
            { Attributes.SkillType.Attack, 1 },
            { Attributes.SkillType.Strength, 1 },
            { Attributes.SkillType.Defence, 1 },
            { Attributes.SkillType.Magic, 1 },
            { Attributes.SkillType.Ranged, 1 },
            { Attributes.SkillType.Agility, 1 },
            { Attributes.SkillType.Charisma, 1},
            { Attributes.SkillType.HealthPoints, 10}
        };

        // Scaling of character
        sizeOfPlayer = new Vector3(1f, 1f, 1f);
    } 
}
