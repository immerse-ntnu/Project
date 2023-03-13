using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    private void Awake()
    {
        BuildDatabase();
    }

    // Find item by id
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }
    
    // Find item by name
    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    private void BuildDatabase()
    {
        items = new List<Item>()
        {
            // Wooden sword
            new(0, "Wood Sword", "This won't do much...",
                new()
                {
                    { "Damage", 1 },
                    { "Defence", 0 }
                }),

            // Copper Sword
            new(1, "Copper Sword", "This can hurt someone. It will probably break easily.",
                new()
                {
                    { "Damage", 3 },
                    { "Defence", 3 }
                }),

            // Copper Ore
            new(2, "Copper Ore", "A shiny ore of copper.",
                new()
                {
                    { "Value", 10 },
                }),
        };
        
        foreach (var item in items)
        {
            var itemObject = new GameObject(item.name);
            var itemComponent = itemObject.AddComponent<Item>();
            itemComponent.id = item.id;
            itemComponent.name = item.name;
            itemComponent.description = item.description;
            itemComponent.Stats = item.Stats;
        }
    }
    
    
}