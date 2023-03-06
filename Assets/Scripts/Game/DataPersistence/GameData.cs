using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class GameData
{
    public int currentPoints;
    public string name;
    public int Strength;
    public int Defence;
    public int Magic;
    public int Ranged;
    public int Agility;
    public int Attack;
    public int HealthPoints;
    

    public GameData()
    {
        // Current points
        currentPoints = 9;
        
        // Character name
        name = "N/A";
        
        // Character skill levels
    } 
}
