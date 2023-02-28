using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    [SerializeField] private Attributes stats;
    [SerializeField] private Attributes.SkillType skill;
    public int currentPoints;
    private void Start()
    {
        stats = FindObjectOfType<Attributes>();
    }

    public GameData()
    {
        this.currentPoints = 9;
    } 
}
