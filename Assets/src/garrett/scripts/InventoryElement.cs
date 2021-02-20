using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryElement : MouseOver
{
	public GameObject weapon; // reference to whatever weapon is in this slot

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
