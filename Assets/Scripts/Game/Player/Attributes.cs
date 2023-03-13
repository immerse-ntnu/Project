using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Attributes : MonoBehaviour
{
    // Player Skills
    public enum SkillType
    {
        Attack,
        Strength,
        Defence,
        Magic,
        Ranged,
        Agility,
        HealthPoints,
        Charisma
    }
    
    // Serializing SkillType as string
    private static readonly string skillSerializePrefix = "";
    public static string SerializeSkillType(SkillType type)
    {
        return skillSerializePrefix + type;
    }
    
    // Deserialize the string back to a SkillType
    public static SkillType DeserializeSkillType(string serial)
    {
        var separated = serial.Replace(skillSerializePrefix, "");
        return Enum.Parse<SkillType>(separated);
    }

    // Starting skill levels as dictionary
    public static Dictionary<SkillType, int> initialSkillLevels = new()
    {
        { SkillType.Attack, 1 },
        { SkillType.Strength, 1 },
        { SkillType.Defence, 1 },
        { SkillType.Magic, 1 },
        { SkillType.Ranged, 1 },
        { SkillType.Agility, 1 },
        { SkillType.Charisma, 1},
        { SkillType.HealthPoints, 10}
    };

    // Define skill levels
    public Dictionary<SkillType, int> skillLevels = new();

    // Define max skill level
    public int maxSkillLevel = 99;
    
    // Defining maximum skill points
    public int maxPoints = 13;

    // Define current skill points
    public int currentPoints = 9;

    public TMP_InputField nameField;
 
    // Player name variable and property to access it from other scripts.
    public string _playerName;
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

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Game"))
        {
            gameObject.transform.position = new Vector3(0f, 0f, 0f);
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
        // Load player scaling
        var localScale = data.sizeOfPlayer;
        gameObject.transform.localScale = new Vector3(localScale.x, localScale.y, localScale.z);
        
        // Load skills
        skillLevels = data.Skills;
        
        // Load player name
        _playerName = data.Name;
    }
    
    public void SaveData(ref GameData data)
    {
        // Save players scaling
        var localScale = this.gameObject.transform.localScale;
        data.sizeOfPlayer = new Vector3(localScale.x, localScale.y, localScale.z);
                    
        // Save player skills
        data.Skills = skillLevels;
        
        // Save player name
        data.Name = _playerName;
    }
    
}