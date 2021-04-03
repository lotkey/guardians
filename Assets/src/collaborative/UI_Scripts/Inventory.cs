using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 4;
    protected List<InventoryItem> items = new List<InventoryItem>();
    // this is the item that the player has "equipped"
    // if the player presses q, this item is dropped
    // if the player picks up an item it goes in this slot, potentially swapping with another weapon
    private int selectedItem = 0; 

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public bool nearPickable = false;
    public GameObject pickableItem = null;

    void Update()
    {
        // check for picking up an item
        if(nearPickable && pickableItem != null)
        {
            
            if(Input.GetAxis("Pickup") > 0)
            {
                InventoryItem current = pickableItem.GetComponent<Pickable>().item;
                // try adding the item to our inventory, if it works, destroy the game object
                if(Add(current))
                {
                    Destroy(pickableItem);
                    // update the UI
                    InventoryUIManager.Instance.UpdateInventory(items);
                }
                //Debug.Log("inventory size = " + items.Count);
            }
            
        }else if(nearPickable && pickableItem == null)
        {
            Debug.Log("pickable item ref is null");
        }

        // Alternatively, drop an item by pressing q
        if(Input.GetAxis("Drop") > 0)
        {
            RemoveAt(selectedItem);
            InventoryUIManager.Instance.UpdateInventory(items);
        }

        // check for item selection
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;

        }else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = 1;

        }else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = 2;

        }else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedItem = 3;
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

    // TODO: provide functionality to set weapon as equipped
    public void EquipItem(int index)
    {
    	// Currently no way to convert type InventoryItem to Weapon
        //this.gameObject.GetComponent<PlayerCombat>().weapon = items[index];
    }

    // Handle detecting pickable inventory items, and enabling UI elements
    void OnTriggerEnter2D(Collider2D other)
    {
        //check -> if the object is a type of inventory item/drop then enable pick up
        if(other.gameObject.tag == "Pickable")
        {
            // enable prompt for player to pick item
            HUDManager.Instance.TogglePrompt("press E to pick up");
            nearPickable = true;

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
            // enable prompt for player to pick item
            HUDManager.Instance.TogglePrompt("");
            nearPickable = false;
        }
    }
}