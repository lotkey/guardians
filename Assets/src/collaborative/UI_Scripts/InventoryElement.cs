using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryElement : MouseOver
{
    // reference to whatever weapon is in this slot
	private InventoryItem weapon;

    public void SetWeapon(InventoryItem newWeapon)
    {
        weapon = newWeapon;
        // update the sprite in the ui element so that the player can see the weapon
        //Debug.Log("updated sprite");
        this.gameObject.GetComponent<Image>().sprite = weapon.icon;
    }

    public InventoryItem GetWeapon()
    {
        return weapon;
    }

    public override void OnPointerEnter(PointerEventData pointerEventData)
    {
    	Debug.Log("Calling pointer enter inventory element");
    	InventoryUIManager.Instance.ShowInventoryItem("test", "this is a test of functionality");
    	base.OnPointerEnter(pointerEventData); // call base OnPointerEnter to get the color change
    }

    public override void OnPointerExit(PointerEventData pointerEventData)
    {
    	base.OnPointerExit(pointerEventData); // reset the color

    	InventoryUIManager.Instance.HideInventoryItem();
    }
}
