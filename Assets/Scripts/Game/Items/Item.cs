using System;
using UnityEngine;
using System.Collections.Generic;
using static System.String;

public class Item : MonoBehaviour
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> Stats;

    // Constructor
    public Item(int id, string title, string desc,
        Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = desc;
        // ReSharper disable once UseStringInterpolation
        this.icon = Resources.Load<Sprite>(Format("Sprites/Items/{0}", title));
        this.Stats = stats;
    }

    // Copy constructor
    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        // ReSharper disable once UseStringInterpolation
        this.icon = Resources.Load<Sprite>(Format("Sprites/Items/{0}", item.title));
        this.Stats = item.Stats;
    }
}
