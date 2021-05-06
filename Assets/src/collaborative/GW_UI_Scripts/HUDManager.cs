using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
	public static HUDManager Instance { get; private set; } // stores reference to singleton instance

	// UI update state variable
	private bool updating;

	// clock state variables
	private float clock_time;
	private bool clock_running = false;
	public Text clock_text;

	private int HP;
	private Slider HP_slider;

	private int nexusHP;
	private Slider NexusHP_slider;

	// state variable, if true, then inventory is hidden
	private bool inv_collapsed = true;

    private GameObject Prompt_Container;

    private GameObject LostGame_Panel;
    private GameObject WonGame_Panel;

    private GameObject Respawn_Panel;


    // Start is called before the first frame update
    void Start()
    {
    	// UI updates by default
    	updating = true;

        // get text element reference for the clock
        clock_text = this.GetComponentInChildren<Text>();

        // get references child game objects that store HUD elements
        HP_slider = this.transform.GetChild(1).GetChild(0).GetComponent<Slider>();
        if(HP_slider == null)
        {
        	Debug.Log("no reference to health slider in HUDManager");
        }

        NexusHP_slider = this.transform.GetChild(2).GetChild(0).GetComponent<Slider>();
        if(NexusHP_slider == null)
        {
        	Debug.Log("no reference to shield slider in HUDManager");
        }

        Prompt_Container = this.transform.GetChild(5).gameObject;
        if(Prompt_Container == null)
        {
            Debug.LogError("no reference to prompt container");
        }

        LostGame_Panel = this.transform.GetChild(6).gameObject;
        if(LostGame_Panel == null)
        {
            Debug.LogError("no reference to lost game panel in HUDManager");
        }

        WonGame_Panel = this.transform.GetChild(7).gameObject;
        if(WonGame_Panel == null)
        {
            Debug.LogError("no reference to won game panel in HUDManager");
        }

        Respawn_Panel = this.transform.GetChild(8).gameObject;
        if(Respawn_Panel == null)
        {
            Debug.LogError("no reference to respawn panel in HUDManager");
        }

        // set default state/visibility of HUD elements
        init(); 
    }

    // called when the game object enters the scene
    private void Awake()
    {
    	if(Instance != null)
    	{
    		Destroy(this.gameObject);
    	}

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
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

        // init NEXUS health
        nexusHP = 500;
        SetNexusHealth(nexusHP);

        // set prompt container active
        Prompt_Container.SetActive(true);

        // init game state panels
        WonGame_Panel.SetActive(false);
        LostGame_Panel.SetActive(false);

        Respawn_Panel.SetActive(false);
    }

    void Update()
    {
    	// check state of wave clock
    	if(clock_running)
    	{
    		// update stored clock value
    		clock_time -= Time.deltaTime; 
    		// update the HUD UI
    		SetClockUI(clock_time);
    	}

    	// check if the UI has been disabled to prevent covering something on-screen
    	if(updating == true)
    	{
    		if(Input.GetKeyDown(KeyCode.Tab))
    		{
                Debug.Log("toggling inventory");
    			ToggleInventory();
    		}
    	}
    	
    }

    // set the value for updating, if true then health, nexusHP, and inventory should take player input
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

    // sets the time remaining on the clock Text element
    public void SetClockUI(float time)
    {
    	clock_text.text = time.ToString("F1");
    }

    // clock begins ticking down, set the clock state to running
    public bool StartClock()
    {
    	clock_running = true;
        return clock_running;
    }

    // clock no longer ticks down, pause the clock state so that it is no longer clicking down
    public bool StopClock()
    {
    	clock_running = false;
        return clock_running;
    }

    // set the value of the hp slider in the UI
    public float SetHP(int hp)
    {
    	HP_slider.value = hp;

        // reference the text mesh pro element attached one of HP_slider's children and set the text value to the current health ratio
        TMPro.TextMeshProUGUI msg = HP_slider.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
        msg.text = hp.ToString() + "/100";

        return HP_slider.value;
    }

    // set the value of the shield slider in the UI, expect this to be called by external scripts
    public float SetNexusHealth(int health)
    {
    	NexusHP_slider.value = health;

        // reference the text mesh pro element attached one of NexusHP_slider's children and set the text value to the current health ratio
        TMPro.TextMeshProUGUI msg = NexusHP_slider.transform.GetChild(3).GetComponent<TMPro.TextMeshProUGUI>();
        NexusHP_slider.value = health;
        msg.text = health.ToString() + "/500";

        return NexusHP_slider.value;
    }

    // toggle the state of the prompt container and return the state of the prompt HUD element
    public bool TogglePrompt(string message)
    { 
        // get reference to hud element and enable it
        Prompt hudelem = this.transform.GetChild(5).GetComponent<Prompt>();
        hudelem.ToggleActive();

        // update the UI text message on the HUD after getting the reference
        TMPro.TextMeshProUGUI msg = hudelem.transform.GetChild(0).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>();
        msg.text = message;

        return hudelem.gameObject.activeSelf;
    }

    // toggle the state of the inventory, when toggle sets active it expands the UI element
    public bool ToggleInventory()
    {
    	InventoryUIManager invmn = InventoryUIManager.Instance.GetComponent<InventoryUIManager>();
        if(invmn == null)
        {
            Debug.LogError("no inventory reference");
            return false;
        }

        // make sure inventory manager is active
        invmn.SetActive(true);

    	if(inv_collapsed)
    	{
            Debug.Log("expanding");
    		invmn.ScaleTo(invmn.expanded, 0.2f);
    		inv_collapsed = false;
            return true;
    	}else{
            Debug.Log("collapsing");
    		invmn.ScaleTo(invmn.minimized, 0.2f);
    		inv_collapsed = true;
            return false;
    	}
    }

    // game over, player lost, so show the panel with that message on the HUD
    public void LostGame()
    {
        LostGame_Panel.SetActive(true);
    }

    // game over, but player won so show congratulatory panel
    public void WonGame()
    {
        Debug.Log("set win true");
        WonGame_Panel.SetActive(true);
    }

    public void ClearEndGameMSG()
    {
        LostGame_Panel.SetActive(false);
        WonGame_Panel.SetActive(false);

        Debug.Log("Lost Game state = " + LostGame_Panel.activeSelf + ", WonGame state = " + WonGame_Panel.activeSelf);
    }

    // show respawn panel with timer till respawn, then init the respawn variables
    public void Respawn()
    {
        Respawn_Panel.SetActive(true);
        Respawn_Panel.GetComponent<RespawnUI>().init();
    }
}