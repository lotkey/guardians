using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int space = 4;
    public List<Weapon> items = new List<Weapon>();
    // this is the item that the player has "equipped"
    // if the player presses q, this item is dropped
    // if the player picks up an item it goes in this slot, potentially swapping with another weapon
    private int selectedItem = 0; 

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    private bool nearPickable = false;
    private GameObject pickableItem = null;

    void Start()
    {
        EquipItem(0);
    }

    void Update()
    {
        // check for picking up an item
        if(nearPickable && pickableItem != null)
        {
            
            if(Input.GetAxis("Pickup") > 0)
            {
                Weapon current = pickableItem.GetComponent<Pickable>().item;
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
        // TODO: Fix bug with dropping items from inventory when one is selected
        //      1) pickup two items
        //      2) equip item 1
        //      3) press q
        if(Input.GetAxis("Drop") > 0)
        {
            RemoveAt(selectedItem);
            EquipPrevious();
            InventoryUIManager.Instance.UpdateInventory(items);
        }

        // check if the player is trying to change their equipped item
        CheckEquipped();
        
    }

    // Check if buttons 1-4 have been pressed, if one has then equip that item
    public void CheckEquipped()
    {
        bool equipChanged = true;

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
        }else{
            equipChanged = false;
        }

        // if player changed selection update equipped item
        if(equipChanged)
        {
            EquipItem(selectedItem);
        }
    }

    public bool Add(Weapon item)
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

    // allow player to remove all but their last weapon
    public void Remove(Weapon item)
    {
        if(items.Count > 1)
        {
            items.Remove(item);
            if (onItemChangedCallback != null) onItemChangedCallback.Invoke();
        }
    }

    // allow player to remove an item if they have more than one and it is in bounds
    public Weapon RemoveAt(int slot)
    {
        // can't remove default weapon
        if(slot == 0) return null;

        if (slot < items.Count && items.Count > 1)
        {
            Weapon item = items[slot];
            items.RemoveAt(slot);
            return item;
        }
        else
        {
            Debug.Log($"No inventory item at slot {slot}!");
            return null;
        }
    }

    public Weapon GetItemAt(int slot)
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

    //provide functionality to set weapon as equipped
    public bool EquipItem(int index)
    {
        // check bounds of array
        if(items.Count > index)
        {
            SoundManager.GetInstance().Play("inventory_sound");

            // update index holder
            selectedItem = index;

            // set wielder
            items[index].wielder = Player.GetPlayer();

            // update the sprite the player is holding
            Sprite pWeaponSprite = this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite;
            pWeaponSprite = items[index].weaponSprite;

            // denote item as equipped by outlining it
            InventoryUIManager.Instance.SetEquipped(index);
            return true;
        }

        return false;
    	
    }

    // equip the next item, wrap when it reaches the end
    public bool EquipNext()
    {
        if(items.Count <= 1) return false;
        return EquipItem((selectedItem+1) % items.Count);
    }

    // equip the current index -1 item, wrap when it reaches the end
    public bool EquipPrevious()
    {
        return EquipItem((selectedItem-1) % items.Count);
    }

    // return the weapon equipped currently, returns null if the inventory is empty
    public Weapon GetEquipped()
    {
        if(selectedItem >= 0 && selectedItem < items.Count)
        {
            return items[selectedItem];
        }else{
            return null;
        }
        
    }

    // clear all but the default weapon
    public bool ClearInventory()
    {
        for(int i = items.Count - 1; i > 0; i--)
        {
            Remove(items[i]);
        }
        return true;
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