using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{
	public static GUIManager Instance {get; private set;}

	public HUDManager hud;
	private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.Find("HUD_Canvas").GetComponent<HUDManager>(); // TODO: clean this up so it's faster
        if(hud == null)
        {
        	Debug.LogError("could not reference HUD");
        }
    }

    // called when the game object enters the scene
    private void Awake()
    {
    	if(Instance != null)
    	{
    		Destroy(this);
    	}

    	Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void TogglePauseMenu()
    {
    	GameObject pMenu = hud.transform.GetChild(4).gameObject;
    	pMenu.SetActive(!pMenu.activeSelf);
    }
}
