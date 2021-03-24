using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	public static HUDManager Instance { get; private set; }

	private bool updating;

	private float clock_time;
	private bool clock_running = false;
	public Text clock_text;

	private int HP;
	private Slider HP_slider;

	private int Shield;
	private Slider Shield_slider;

	private bool inv_collapsed = true;
	private GameObject Inventory;


    // Start is called before the first frame update
    void Start()
    {
    	updating = true;

        // get text element reference for the clock
        clock_text = this.GetComponentInChildren<Text>();

        // get slider references
        HP_slider = this.transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        if(HP_slider == null)
        {
        	Debug.Log("no reference to health slider in HUDManager");
        }

        Shield_slider = this.transform.GetChild(2).GetChild(0).GetComponent<Slider>();
        if(Shield_slider == null)
        {
        	Debug.Log("no reference to shield slider in HUDManager");
        }

        // get the reference to the inventory element
        Inventory = this.transform.GetChild(3).gameObject;
        if(Inventory == null || Inventory.name != "Inventory_HUDElement")
        {
        	Debug.Log("not the right HUDElement");
        }

        //init();
    }

    // called when the game object enters the scene
    private void Awake()
    {
    	if(Instance != null)
    	{
    		Destroy(this);
    	}
    }

    // function called to set default values of all HUDElements
    private void init()
    {
    	// init clock
        clock_time = 0f;
        clock_running = false;
        SetClockUI(clock_time);

        // init HP
        HP = 100;
        SetHP(HP);

        // init Shield
        Shield = 100;
    }

    void Update()
    {
    	if(clock_running)
    	{
    		// update clock
    		clock_time -= Time.deltaTime;
    		SetClockUI(clock_time);
    	}

    	if(updating == true)
    	{
    		// poll hp and shield values from player script
    		if(Input.GetKeyDown(KeyCode.Tab))
    		{
    			ToggleInventory();
    			SetHP(13);
    			SetShield(10);
    		}
    	}
    	
    }

    // set the value for updating, if true then health, shield, and inventory should take player input
    public void SetUpdate(bool updateable)
    {
    	updating = updateable;
    }

    // set the value stored by the script, if the clock is started this is the value it will be started at
    public void SetClockTime(float time)
    {
        clock_time = time;
        SetClockUI(time);
    }

    // return the amount of time left on the clock
    public float GetClockTime()
    {
        return clock_time;
    }

    // Sets the time remaining on the clock
    public void SetClockUI(float time)
    {
    	clock_text.text = time.ToString("F1");
    }

    // Clock begins ticking down
    public bool StartClock()
    {
    	clock_running = true;
        return clock_running;
    }

    // Clock no longer ticks down
    public bool StopClock()
    {
    	clock_running = false;
        return clock_running;
    }

    // set the value of the hp slider
    public float SetHP(int hp)
    {
    	HP_slider.value = hp;
        return HP_slider.value;
    }

    // set the value of the shield slider
    public float SetShield(int shield)
    {
    	Shield_slider.value = shield;
        return Shield_slider.value;
    }

    // toggle the state of the inventory
    public bool ToggleInventory()
    {
        if(Inventory == null)
        {
            // try getting the reference again
            Inventory = this.transform.GetChild(3).gameObject;
            if(Inventory == null)
            {
                Debug.LogError("could not get inventory ref");
                return false;
            }
        }
    	InventoryUIManager invmn = Inventory.GetComponent<InventoryUIManager>();
        if(invmn == null)
        {
            Debug.LogError("no inventory reference");
            return false;
        }

        invmn.SetActive(true);

    	if(inv_collapsed)
    	{
    		Inventory.GetComponent<InventoryUIManager>().ScaleTo(1, 1, 1, 0.2f);
    		inv_collapsed = false;
            return true;
    	}else{
    		Inventory.GetComponent<InventoryUIManager>().ScaleTo(0, 1, 1, 0.2f);
    		inv_collapsed = true;
            return false;
    	}
    	
    }
}