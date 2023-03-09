using UnityEngine;

public class SaveCharacter : MonoBehaviour
{   
    // Script that everytime it is run, it saves the game (for use on buttons etc)
    public void SaveSkills(ref GameData data)
    {
        foreach (var kvp in data.SavedSkill)
        {
            var skill = (Attributes.DeserializeSkillType(kvp.Key));
            Attributes.initialSkillLevels.Add(skill, kvp.Value);
            Debug.Log("Skill saved: " +  skill + ", Level saved: " + kvp.Value );
        }
    }
    
    // Load the skills from the JSON file
    public void LoadSkills(GameData data)
    {
        foreach (var kvp in Attributes.initialSkillLevels)
        {
            var skill = (Attributes.SerializeSkillType(kvp.Key));
            data.SavedSkill.Add(skill, kvp.Value);
            Debug.Log("Skill loaded: " +  skill + ", Level loaded: " + kvp.Value );
        }
    }
}
