using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerController controller;
    public EntityAnimator playerArmsAnimator;
    public bool nearPickable = false;
    public static Player instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        // TODO: check -> if the object is a type of inventory item/drop then enable pick up
        // TODO: enable prompt for player to pick item
    }

    // Handle detecting movement away from inventory items and disabling corresponding UI elements
    void OnTriggerExit2D(Collider2D other)
    {
        // TODO: disable prompt to pick item, set nearPickable false
    }
}
