using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class HUDElement : MonoBehaviour
{

	// flip the active state of the child game objects
    public void ToggleActive()
    {
    	Transform[] children = GetComponentsInChildren<Transform>();

    	foreach(Transform trans in children)
    	{
    		trans.gameObject.SetActive(!trans.gameObject.active);
    	}
    }

    // Set all child game objects to inactive
    public void SetActive(bool active)
    {
    	Transform[] children = GetComponentsInChildren<Transform>();

    	foreach(Transform trans in children)
    	{
    		trans.gameObject.SetActive(!trans.gameObject.active);
    	}
    }

    // scale all child game objects to the specified size
    public void ScaleTo(float x, float y, float z, float dur_seconds)
    {
    	LeanTween.scale(this.gameObject.transform.GetChild(0).gameObject, new Vector3(x, y, z), dur_seconds);

    	/*
    	Transform[] children = GetComponentsInChildren<Transform>();

    	foreach(Transform trans in children)
    	{
    		LeanTween.scale(trans.gameObject, Vector3(x, y, z), dur_seconds);
    	}
    	*/
    }
}
