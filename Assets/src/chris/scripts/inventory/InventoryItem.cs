using UnityEngine;
using UnityEngine.Assertions;
public class InventoryItem
{
    protected string name = "New Item";
    protected Sprite icon = null;
    protected string[] attributes;
    protected float[] attributeValues;

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