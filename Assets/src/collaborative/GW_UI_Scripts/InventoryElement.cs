using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// This class will be attached to a prefab and allow player to hover over weapon image and see stats
// Also allows the player to manage the data stored by the Inventory
public class InventoryElement : MouseOver
{
    // reference to whatever weapon is in this slot
	private Weapon weapon;
    // reference to the UI image outline
    private UnityEngine.UI.Image outline;
    // a sprite of the weapon shown in the UI
    private UnityEngine.UI.Image weaponImage;

    public void Awake()
    {
        weaponImage = this.transform.GetChild(0).gameObject.GetComponent<Image>();
        outline = this.gameObject.GetComponent<Image>();

        SetUnequipped();
    }

    // change weapon and image stored by this script
    public void SetWeapon(Weapon newWeapon)
    {
        weapon = newWeapon;

        // update the sprite in the ui element so that the player can see the weapon        
        weaponImage.sprite = weapon.icon;
    }

    // set the outline of the gameobject to visible
    public void SetEquipped()
    {
        Color opaque = new Color(outline.color.r, outline.color.g, outline.color.b, 1);
        outline.color = opaque;
    }

    // set the outline of the gameobject to invisible
    public void SetUnequipped()
    {
        Color clear = new Color(outline.color.r, outline.color.g, outline.color.b, 0);
        outline.color = clear;
    }

    // get the reference to the weapon attached to this script
    public Weapon GetWeapon()
    {
        return weapon;
    }

    // override the MouseOver OnPointerEnter function
    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
    	if(weapon != null) InventoryUIManager.Instance.ShowInventoryItem(weapon.name, weapon.ToString());
    	base.OnPointerEnter(pointerEventData); // call base OnPointerEnter to get the color change
    }

    // override the MouseOver OnPointerExit function
    public override void OnPointerExit(PointerEventData pointerEventData)
    {
    	base.OnPointerExit(pointerEventData); // reset the color
    	InventoryUIManager.Instance.HideInventoryItem();
    }
}
