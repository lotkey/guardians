using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public Color Selected = Color.black;
	private Color Normal;

	void Start()
	{
		Normal = this.gameObject.GetComponent<Image>().color;
	}

	//Detect if the Cursor starts to pass over the GameObject
    public virtual void OnPointerEnter(PointerEventData pointerEventData)
    {
    	//Debug.Log("Calling mouse over");
        this.gameObject.GetComponent<Image>().color = Selected;
    }

    //Detect when Cursor leaves the GameObject
    public virtual void OnPointerExit(PointerEventData pointerEventData)
    {
        this.gameObject.GetComponent<Image>().color = Normal;
    }
}
