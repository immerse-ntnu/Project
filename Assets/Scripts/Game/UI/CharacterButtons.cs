using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour
{
    public Attributes.SkillType skill;
    public Image skillLevelImage;
    public Sprite[] spriteArray;
    public Attributes stats;
    public new Transform transform;
    [SerializeField] private GameObject player;
    
    private void Start()
    {
        stats = FindObjectOfType<Attributes>();
        UpdateSkillLevelImage();
        Debug.Log("Points: " + stats.currentPoints);
        Debug.Log("Skill level: " + stats.GetSkillLevel(skill));
    }

    public void IncrementSkillLevel()
    {
        if (stats.currentPoints > 0 && stats.GetSkillLevel(skill) < 9)
        {
            stats.ChangeSkillLevel(skill, 1, false); // Increment skill by 1
            UpdateSkillLevelImage();
            Debug.Log("Points: " + stats.currentPoints);
            Debug.Log("Skill level: " + stats.GetSkillLevel(skill));
        }
    }

    public void AddSize()
    {
        if (player.transform.localScale.x < 1.3 && player.transform.localScale.y < 1.5)
        {
            player.transform.localScale += new Vector3(0.05f, 0.05f, 0f);
        }
    }
    
    public void RemoveSize()
    {
        if (player.transform.localScale.x > 1.0 && player.transform.localScale.y > 1.0)
        {
            player.transform.localScale -= new Vector3(0.05f, 0.05f, 0f);
        }
    }
    

    public void DecrementSkillLevel()
    {
        if (stats.currentPoints >= 0 && stats.GetSkillLevel(skill) > 1)
        {
            stats.ChangeSkillLevel(skill, -1, true); // Increment skill by 1
            UpdateSkillLevelImage();
        }
        
        // Debug.Log("Points: " + stats.currentPoints);
        // Debug.Log("Attack: " + stats.GetSkillLevel(Attributes.SkillType.Attack));

    }
    
    private void UpdateSkillLevelImage()
    {
        int skillLevel = stats.GetSkillLevel(skill);
        if (skillLevel >= 1 && skillLevel <= spriteArray.Length)
        {
            skillLevelImage.sprite = spriteArray[skillLevel - 1];
        }
    }
}