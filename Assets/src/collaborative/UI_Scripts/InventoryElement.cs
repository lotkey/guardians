using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryElement : MouseOver
{
    // reference to whatever weapon is in this slot
	private InventoryItem weapon;
    private UnityEngine.UI.Image outline;
    private UnityEngine.UI.Image weaponImage;

    public void Awake()
    {
        weaponImage = this.transform.GetChild(0).gameObject.GetComponent<Image>();
        outline = this.gameObject.GetComponent<Image>();

        SetUnequipped();
    }

    // store the reference to the weapon in this script
    public void SetWeapon(InventoryItem newWeapon)
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
        Debug.Log(outline.color.r);
        Color clear = new Color(outline.color.r, outline.color.g, outline.color.b, 0);
        outline.color = clear;
    }

    // get the reference to the weapon attached to this script
    public InventoryItem GetWeapon()
    {
        return weapon;
    }

    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
    	//Debug.Log("Calling pointer enter inventory element");
    	InventoryUIManager.Instance.ShowInventoryItem(weapon.name, weapon.ToString());
    	base.OnPointerEnter(pointerEventData); // call base OnPointerEnter to get the color change
    }

    public override void OnPointerExit(PointerEventData pointerEventData)
    {
    	base.OnPointerExit(pointerEventData); // reset the color

    	InventoryUIManager.Instance.HideInventoryItem();
    }
}
