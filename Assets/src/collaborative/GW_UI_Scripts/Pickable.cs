using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this stores the pickable item data, quantity, and name
public class Pickable : MonoBehaviour
{
	public Weapon item;
	public string name = "Item Name Here";
	public int amount = 1;

	void Start()
	{
		// make sure this item can be recognized as pickable by colliding objects
		this.tag = "Pickable";
		if(item == null)
		{
			Debug.LogError("no weapon script attached to item drop: " + this.name);
		}
	}
}
