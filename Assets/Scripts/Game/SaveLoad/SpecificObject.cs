using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificObject : SavableObject
{
    private float attack, strength, defence, agility;

    public override void Save(int id)
    {
        base.Save(id);
    }

    public override void Load(string[] values)
    {
        base.Load(values);
    }
}
