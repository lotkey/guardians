using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryElement : MouseOver
{
    // reference to whatever weapon is in this slot
	public InventoryItem weapon 
    {
        get{ return weapon;}

        set
        { 
            weapon = value;
            // TODO: this should update the sprite on the game object so that the player can see the item in the inventory
            //this.gameObject.GetComponent<Image>().sprite = weapon.icon;
        }
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
