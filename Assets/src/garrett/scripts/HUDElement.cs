using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;

public class HUDElement : MonoBehaviour
{
	public bool activeDefault = false;
	public float duration = 0.2f;
	public Vector3 expanded;
	public Vector3 minimized;

	// flip the active state of the child game objects
    public void ToggleActive()
    {
    	this.SetActive(!this.transform.GetChild(0).gameObject.activeSelf);
    }

    // set the container object below this to inactive
    public void SetActive(bool state)
    {
    	this.transform.GetChild(0).gameObject.SetActive(state);
    }

    // scale all child game objects to the specified size
    public void ScaleTo(float x, float y, float z, float dur_seconds)
    {
    	LeanTween.scale(this.gameObject.transform.GetChild(0).gameObject, new Vector3(x, y, z), dur_seconds);
    }

    // scale the HUDelement based on the chosen settings in the editor
    public void ScaleTo(Vector3 scale, float duration)
    {
    	LeanTween.scale(this.gameObject.transform.GetChild(0).gameObject, scale, duration);
    }
}
