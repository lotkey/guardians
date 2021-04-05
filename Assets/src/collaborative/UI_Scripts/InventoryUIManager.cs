using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryUIManager : HUDElement
{
	public static InventoryUIManager Instance { get; private set; }
    private GameObject inventoryPreview_Panel;
	private GameObject inventoryDesc_Panel;

    public GameObject inventoryIcon_Prefab;

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
    public void UpdateInventory(List<InventoryItem> inventoryContents)
    {
        InventoryElement[] guiObjects = inventoryPreview_Panel.transform.GetComponentsInChildren<InventoryElement>();
        int j = 0;
        // check if the number of guiObjects is fewer than the elements in inventory
        // if there are not enough slots, instantiate some
        // if there are too many slots, remove extras
        if(inventoryContents.Count > guiObjects.Length)
        {
            //Debug.Log("more items in inventory than UI");
            int diff = inventoryContents.Count - guiObjects.Length;
            for(j = 0; j < diff; j++)
            {
                // instantiate new object
                GameObject newEntry = Instantiate(inventoryIcon_Prefab) as GameObject;
                newEntry.transform.SetParent(inventoryPreview_Panel.transform);
                newEntry.transform.localScale = this.transform.localScale;
            }
            j = 0;

        }else if(inventoryContents.Count < guiObjects.Length)
        {
            // remove excess elements from visual space
            int diff = guiObjects.Length - inventoryContents.Count;
            //Debug.Log("excess items in UI, differs by " + diff);
            for(j = 0; j < diff; j++)
            {
                // destroy old object
                //Debug.Log("Destroying " + guiObjects[j].gameObject.name);
                Destroy(guiObjects[j].gameObject);
            }
        }

        // now, set the remaining items to store inventory items
        // start by reseting guiObjects
        guiObjects = inventoryPreview_Panel.transform.GetComponentsInChildren<InventoryElement>();
        int i = j;
    	foreach(InventoryItem item in inventoryContents)
        {
            //Debug.Log("Setting " + guiObjects[i].gameObject.name + " to " + item.name);
            guiObjects[i].SetWeapon(item);
            i++;
        }
    	
    }

    public void SetEquipped(int index)
    {
        InventoryElement[] guiObjects = inventoryPreview_Panel.transform.GetComponentsInChildren<InventoryElement>();

        int i = 0;
        foreach(InventoryElement item in guiObjects)
        {
            if(i != index)
            {
                // deactivate outline
                item.SetUnequipped();

            }else{
                // activate the outline
                item.SetEquipped();
            }

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
