using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes : MonoBehaviour, IDataPersistence
{
    public enum SkillType
    {
        Attack,
        Strength,
        Defence,
        Magic,
        Ranged,
        Agility,
        HealthPoints
    }

    public string ReadInput; // Character name

    private Dictionary<SkillType, int> initialSkillLevels = new Dictionary<SkillType, int>()
    {
        { SkillType.Strength, 1 },
        { SkillType.Defence, 1 },
        { SkillType.Magic, 1 },
        { SkillType.Ranged, 1 },
        { SkillType.Agility, 1 },
        { SkillType.Attack, 1 },
        { SkillType.HealthPoints, 10 }
    };

    // Define skill levels
    private Dictionary<SkillType, int> skillLevels = new Dictionary<SkillType, int>();

    // Define max skill level
    public int maxSkillLevel = 99;

    public int maxPoints = 13;

    // Define current skill points
    public int currentPoints = 13;

    // Input from input field
    public ReadInput Input;
    
    private void Awake()
    {
        Input = FindObjectOfType<ReadInput>();
        // Set skill levels to initial values
        foreach (var kvp in initialSkillLevels)
        {
            skillLevels.Add(kvp.Key, kvp.Value);
        }
    }

    // Function for changing skill levels
    public void ChangeSkillLevel(SkillType skill, int amount, bool Decrement)
    {
        // Check if current points are greater than 0 and skill level is less than max level
        if (currentPoints > 0 && skillLevels[skill] < maxSkillLevel)
        {
            // Add or subtract skill level
            skillLevels[skill] += amount;
            currentPoints -= amount;
        }
        else if (Decrement == true && currentPoints >= 0)
        {
            // Add or subtract skill level
            skillLevels[skill] += amount;
            currentPoints -= amount;
        }

        if (skillLevels[skill] < 1)
        {
            skillLevels[skill] = 1;
        }
    }
    
    
    public void ChangeName()
    {
        this.name = Input.input;
    }

    // Function for getting current skill level
    public int GetSkillLevel(SkillType skill)
    {
        return skillLevels[skill];
    }

    private void Update()
    {
        if (currentPoints > maxPoints)
        {
            currentPoints = maxPoints;
        }
    }

    public void LoadData(GameData data)
    {
        // Load character name  
        this.name = data.name;
    }

    public void SaveData(ref GameData data)
    {
        // Save character name
        data.name = this.name;
    }
}