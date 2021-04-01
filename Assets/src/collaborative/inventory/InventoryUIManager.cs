using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : HUDElement
{
	public static InventoryUIManager Instance { get; private set; }
    private GameObject inventoryPreview_Panel;
	private GameObject inventoryDesc_Panel;

    // Start is called before the first frame update
    void Start()
    {
        this.SetActive(activeDefault); // set the default state of this element

        inventoryDesc_Panel = this.transform.GetChild(0).GetChild(1).gameObject; // reference to the description panel
        if(inventoryDesc_Panel == null)
        {
        	Debug.LogError("no reference to inventory description panel");
        }

        inventoryDesc_Panel.SetActive(false);

        inventoryPreview_Panel = this.transform.GetChild(0).GetChild(0).gameObject; // reference to the description panel
        if(inventoryPreview_Panel == null)
        {
            Debug.LogError("no reference to inventory preview panel");
        }
    }

    void Awake()
    {
    	if(Instance != null)
    	{
    		Destroy(this.gameObject);
    	}else{
    		Instance = this;
    	}
    }


    // Update the contents of the inventory... 
    // Iterate through all Weapons and set them to the corresponding inventory element
    // TODO: make sure this is called from the player inventory script
    public void UpdateInventory(List<InventoryItem> inventoryContents)
    {
        InventoryElement[] guiObjects = inventoryPreview_Panel.transform.GetComponentsInChildren<InventoryElement>();

        int i = 0;

    	foreach(InventoryItem item in inventoryContents)
        {
            guiObjects[i].weapon = item;
            i++;
        }
    	
    }

    // set the values for the inventory display panel, name and description, then set the panel to active
    // returns the state of the inventory item
    public bool ShowInventoryItem(string name, string description)
    {
    	inventoryDesc_Panel.SetActive(true);

    	TMPro.TextMeshProUGUI nameStr = inventoryDesc_Panel.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
    	TMPro.TextMeshProUGUI descr = inventoryDesc_Panel.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();

    	nameStr.text = name;
    	descr.text = description;

        return inventoryDesc_Panel.activeSelf;
    }

    // hide the panel for the inventory item description and clear it's values
    public bool HideInventoryItem()
    {
    	inventoryDesc_Panel.SetActive(false);

    	TMPro.TextMeshProUGUI nameStr = inventoryDesc_Panel.transform.GetChild(1).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
    	TMPro.TextMeshProUGUI descr = inventoryDesc_Panel.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();

    	nameStr.text = "";
    	descr.text = "";

        return inventoryDesc_Panel.activeSelf;
    }
}
