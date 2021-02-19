using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	private bool updating;

	private float clock_time;
	private bool clock_running;
	public Text clock_text;

	private int HP;
	private Slider HP_slider;

	private int Shield;
	private Slider Shield_slider;

	private bool inv_collapsed = false;
	private GameObject Inventory;


    // Start is called before the first frame update
    void Start()
    {
    	updating = true;

        // get text element reference for the clock
        clock_text = this.GetComponentInChildren<Text>();

        // get slider references
        Slider[] sliders = this.GetComponentsInChildren<Slider>();
        foreach(Slider slider in sliders)
        {
        	if(slider.gameObject.name == "HP_Slider")
        	{
        		HP_slider = slider;
        	}else if(slider.gameObject.tag == "Shield_Slider")
        	{
        		Shield_slider = slider;
        	}
        }

        Inventory = this.transform.GetChild(3).gameObject;
        if(Inventory.name != "Inventory_HUDElement")
        {
        	Debug.Log("not the right HUDElement");
        }
    }

    // function called to set default values of all HUDElements
    private void init()
    {
    	// init clock
        clock_time = 0f;
        clock_running = false;
        SetClock(clock_time);

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
    		SetClock(clock_time);
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

    // Sets the time remaining on the clock
    public void SetClock(float time)
    {
    	clock_text.text = time.ToString("F1");
    }

    // Clock begins ticking down
    public void StartClock()
    {
    	clock_running = true;
    }

    // Clock no longer ticks down
    public void StopClock()
    {
    	clock_running = false;
    }

    // set the value of the hp slider
    public void SetHP(int hp)
    {
    	HP_slider.value = hp;
    }

    // set the value of the shield slider
    public void SetShield(int shield)
    {
    	Shield_slider.value = shield;
    }

    // toggle the state of the inventory
    private void ToggleInventory()
    {
    	//Inventory.SetActive(!Inventory.activeSelf);
    	if(inv_collapsed)
    	{
    		Inventory.GetComponent<HUDElement>().ScaleTo(1, 1, 1, 0.2f);
    		inv_collapsed = false;
    	}else{
    		Inventory.GetComponent<HUDElement>().ScaleTo(0, 1, 1, 0.2f);
    		inv_collapsed = true;
    	}
    	
    }
}