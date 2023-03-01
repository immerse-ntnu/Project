using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    [SerializeField] private Attributes stats;
    [SerializeField] private Attributes.SkillType skill;
    private ReadInput input;
    public int currentPoints;
    public string name;
    
    private void Start()
    {
        stats = FindObjectOfType<Attributes>();
        input = FindObjectOfType<ReadInput>();
    }

    public GameData()
    {
        this.currentPoints = 9;
        this.name = "";
    } 
}
