using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    
    private Dictionary<SkillType, int> initialSkillLevels = new()
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
    private Dictionary<SkillType, int> skillLevels = new();

    // Define max skill level
    public int maxSkillLevel = 99;

    public int maxPoints = 13;

    // Define current skill points
    public int currentPoints = 13;
    
    public TMP_InputField nameField;
 
    // Player name variable and property to access
    // it from other scripts.
    private string _playerName;
    
    public string PlayerName
    {
        get => _playerName;
        set => Debug.Log("You are not allowed to set the player name like that");
    }

    private void Awake()
    {
        // Set skill levels to initial values
        foreach (var kvp in initialSkillLevels)
        {
            skillLevels.Add(kvp.Key, kvp.Value);
        }
    }

    // Function for changing skill levels
    public void ChangeSkillLevel(SkillType skill, int amount, bool decrement)
    {
        // Check if current points are greater than 0 and skill level is less than max level
        if (currentPoints > 0 && skillLevels[skill] < maxSkillLevel)
        {
            // Add or subtract skill level
            skillLevels[skill] += amount;
            currentPoints -= amount;
        }
        else if (decrement == true && currentPoints >= 0)
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

    //Use this on a "Submit" button to set the playerName variable.
    public void SubmitName()
    {
        if(string.IsNullOrEmpty(nameField.text) == false)
        {
            _playerName = nameField.text;
        }
    }
    
    public void LoadData(GameData data)
    {
        // Load character name
        this._playerName = data.name;
        this.currentPoints = data.currentPoints;
    }

    public void SaveData(ref GameData data)
    {
        // Save character name
        data.name = this._playerName;
        data.currentPoints = this.currentPoints;
    }
}