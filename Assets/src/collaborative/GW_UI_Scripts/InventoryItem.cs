using UnityEngine;
using UnityEngine.Assertions;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventory Item", menuName = "ScriptableObjects/InventoryItem", order = 1)]
[Serializable]
public class InventoryItem : ScriptableObject
{
    public new string name = "New Item";
    public Sprite icon = null;
    public List<string> attributes = new List<string>();
    public List<float> attributeValues = new List<float>();
    public Weapon weapon;

    public InventoryItem(string name, Sprite icon, List<string> attributes, List<float> attributeValues)
    {
        Assert.IsTrue(attributeValues.Count == attributes.Count);
        this.name = name;
        this.icon = icon;
        this.attributes = attributes;
        this.attributeValues = attributeValues;
    }

    public override string ToString()
    {
        //string description = name;
        string description = "";
        for (int i = 0; i < attributes.Count; i++)
        {
            description += $"\n{attributes[i]}: {attributeValues[i]}";
        }
        return description;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}