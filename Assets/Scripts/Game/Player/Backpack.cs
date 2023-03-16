using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Backpack : MonoBehaviour
{
    public InventoryObject inventory; // give player inventory

    private void OnTriggerEnter2D(Collider2D other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item,1);
            Destroy(other.gameObject);
        }
    }
}