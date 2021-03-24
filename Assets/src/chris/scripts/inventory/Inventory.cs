using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 20;
    public List<Item> items = new List<Item>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool Add(Item item)
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

    public void Remove(Item item)
    {
        items.Remove(item);
        if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
    }
}