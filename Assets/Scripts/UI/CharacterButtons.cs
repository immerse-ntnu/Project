using UnityEngine;
using UnityEngine.UI;

public class CharacterButtons : MonoBehaviour
{
    public Attributes.SkillType skill;
    public Image skillLevelImage;
    public Sprite[] spriteArray;

    private Attributes stats;
    private SpriteChanger spriteChanger;
    
    private void Start()
    {
        stats = FindObjectOfType<Attributes>();
        spriteChanger = new SpriteChanger(skillLevelImage, spriteArray);
    }

    public void IncrementSkillLevel()
    {
        if (stats.currentPoints > 0 && stats.GetSkillLevel(skill) < 9)
        {
            stats.currentPoints--;
            stats.ChangeSkillLevel(skill, 1); // Increment skill by 1
            spriteChanger.ChangeSprite(stats.GetSkillLevel(skill)-1);
            //Debug.Log("Points: " + stats.currentPoints);
            //Debug.Log("Attack: " + stats.GetSkillLevel(Attributes.SkillType.Attack));
        }
    }

    public void DecrementSkillLevel()
    {
        if (stats.currentPoints >= 0 && stats.currentPoints < stats.maxPoints && stats.GetSkillLevel(skill) > 1)
        {
            stats.ChangeSkillLevel(skill, -1); // Decrement skill by 1
            spriteChanger.ChangeSprite(stats.GetSkillLevel(skill)-1);
            stats.currentPoints++;
            // Debug.Log("Points: " + stats.currentPoints);
            // Debug.Log("Attack: " + stats.GetSkillLevel(Attributes.SkillType.Attack));
        }
    }
}
