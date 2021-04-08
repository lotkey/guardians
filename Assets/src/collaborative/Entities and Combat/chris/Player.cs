using UnityEngine;

public class Player : Entity
{
    public EntityAnimator playerArmsAnimator;
    public bool nearPickable = false;
    public static Player instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("There are multiple players! This is bad!");
        }
    } 

    void Update()
    {
        if(nearPickable)
        {
            // TODO: enable prompt to pick item from the ground
        }
    }

    public static Player GetPlayer()
    {
        return instance;
    }

    // Handle detecting pickable inventory items, and enabling UI elements
    void OnTriggerEnter2D(Collider2D other)
    {
        // TODO Chris: enable automatic health pickups

        // TODO: check -> if the object is a type of inventory item/drop then enable pick up
        // TODO: enable prompt for player to pick item
    }

    // Handle detecting movement away from inventory items and disabling corresponding UI elements
    void OnTriggerExit2D(Collider2D other)
    {
        // TODO: disable prompt to pick item, set nearPickable false
    }
}
