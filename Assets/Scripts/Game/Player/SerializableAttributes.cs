using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SerializableAttributes
{
    public Dictionary<Attributes.SkillType, int> initialSkillLevels;

    public SerializableAttributes(Dictionary<Attributes.SkillType, int> skillLevels)
    {
        initialSkillLevels = skillLevels;
    }
}

public class JsonSaveLoad : MonoBehaviour
{
    private SerializableAttributes  skillLevelsData;

    private void Awake()
    {
        skillLevelsData = new SerializableAttributes (Attributes.initialSkillLevels);
    }

    private void SaveJson()
    {
        string json = JsonUtility.ToJson(skillLevelsData);
        System.IO.File.WriteAllText(Application.dataPath + "/SkillLevels.json", json);
    }
}