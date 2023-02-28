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

    

    private void Awake()
    {
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
        this.currentPoints = data.currentPoints;
    }

    public void SaveData(ref GameData data)
    {
        data.currentPoints = this.currentPoints;
    }
    
    
}
