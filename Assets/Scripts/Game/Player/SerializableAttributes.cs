using System;
using System.Collections.Generic;

[Serializable]
public class SerializableAttributes
{
    public int strength;
    public int defence;
    public int magic;
    public int ranged;
    public int agility;
    public int attack;
    public int healthPoints;

    public SerializableAttributes(Dictionary<Attributes.SkillType, int> dict)
    {
        strength = dict[Attributes.SkillType.Strength];
        defence = dict[Attributes.SkillType.Defence];
        magic = dict[Attributes.SkillType.Magic];
        ranged = dict[Attributes.SkillType.Ranged];
        agility = dict[Attributes.SkillType.Agility];
        attack = dict[Attributes.SkillType.Attack];
        healthPoints = dict[Attributes.SkillType.HealthPoints];
    }
    
};
    