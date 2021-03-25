using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 4;
    protected List<InventoryItem> items = new List<InventoryItem>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(InventoryItem item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough space in inventory!");
            return false;
        }
        else
        {
            items.Add(item);
            if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
            return true;
        }
    }

    public void Remove(InventoryItem item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }

    public InventoryItem RemoveAt(int slot)
    {
        if (slot < items.Count)
        {
            InventoryItem item = items[slot];
            items.RemoveAt(slot);
            return item;
        }
        else
        {
            Debug.Log($"No inventory item at slot {slot}!");
            return null;
        }
    }

    public InventoryItem GetItemAt(int slot)
    {
        if (slot < items.Count)
        {
            return items[slot];
        }
        else
        {
            Debug.Log($"No inventory item at slot {slot}!");
            return null;
        }
    }
}