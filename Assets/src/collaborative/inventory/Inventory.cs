using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 4;
    protected List<InventoryItem> items = new List<InventoryItem>();

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool nearPickable = false;
    public GameObject pickableItem = null;

    void Update()
    {
        if(nearPickable && pickableItem != null)
        {
            
            if(Input.GetKeyDown(KeyCode.E))
            {
                InventoryItem current = pickableItem.GetComponent<Pickable>().item;
                // try adding the item to our inventory, if it works, destroy the game object
                if(Add(current))
                {
                    Destroy(pickableItem);
                    // TODO: update the UI
                    InventoryUIManager.Instance.UpdateInventory(items);
                }
                Debug.Log("inventory size = " + items.Count);
            }
            
        }else if(nearPickable && pickableItem == null)
        {
            Debug.Log("pickable item ref is null");
        }
    }

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

    // Handle detecting pickable inventory items, and enabling UI elements
    void OnTriggerEnter2D(Collider2D other)
    {
        //check -> if the object is a type of inventory item/drop then enable pick up
        if(other.gameObject.tag == "Pickable")
        {
            // enable prompt for player to pick item
            if(HUDManager.Instance == null) 
            {
                HUDManager hdman = GameObject.Find("HUD_Canvas").GetComponent<HUDManager>();
                hdman.TogglePrompt("press E to pick up");
                nearPickable = true;
            }else{
                HUDManager.Instance.TogglePrompt("press E to pick up");
                nearPickable = true;
            }

            // store the item we are near so that we can destroy the gameobject if it is picked up
            pickableItem = other.gameObject;
        }
    }

    // Handle detecting movement away from inventory items and disabling corresponding UI elements
    void OnTriggerExit2D(Collider2D other)
    {
        // disable prompt to pick item, set nearPickable false
        //Debug.Log("Left trigger of " + other.gameObject.name);
        if(other.gameObject.tag == "Pickable")
        {
            //HUDManager.Instance = GameObject.Find("HUD_Canvas").GetComponent<HUDManager>();
            // enable prompt for player to pick item
            if(HUDManager.Instance == null) 
            {
                HUDManager hdman = GameObject.Find("HUD_Canvas").GetComponent<HUDManager>();
                hdman.TogglePrompt("");
                nearPickable = false;
            }else{
                HUDManager.Instance.TogglePrompt("");
                nearPickable = false;
            }

            
        }
    }
}