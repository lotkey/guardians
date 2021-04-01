using UnityEngine;
using UnityEngine.Assertions;
using System;

[CreateAssetMenu(fileName = "Inventory Item", menuName = "ScriptableObjects/InventoryItem", order = 1)]
[Serializable]
public class InventoryItem : ScriptableObject
{
    public string name = "New Item";
    public Sprite icon = null;
    public string[] attributes;
    public float[] attributeValues;

    public InventoryItem(string name, Sprite icon, string[] attributes, float[] attributeValues)
    {
        Assert.IsTrue(attributeValues.Length == attributes.Length);
        this.name = name;
        this.icon = icon;
        this.attributes = attributes;
        this.attributeValues = attributeValues;
    }

    public override string ToString()
    {
        string description = name;
        for (int i = 0; i < attributes.Length; i++)
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