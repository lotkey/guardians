using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    Transform Main_Panel;
    Transform Settings_Panel;
    Transform Credits_Panel;

    // Start is called before the first frame update
    void Start()
    {
        Main_Panel = this.gameObject.transform.GetChild(0);
        if(Main_Panel == null)
        {
        	Debug.LogError("No reference to main panel of main menu found");
        }

        Settings_Panel = this.gameObject.transform.GetChild(1);
        if(Settings_Panel == null)
        {
        	Debug.LogError("No reference to settings panel found");
        }

        Credits_Panel = this.gameObject.transform.GetChild(2);
        if(Credits_Panel == null)
        {
        	Debug.LogError("No reference to credits panel found");
        }

        init();
    }

    // Set the default value of the panels
    private void init()
    {
    	Main_Panel.gameObject.SetActive(true);
    	Settings_Panel.gameObject.SetActive(false);
    	Credits_Panel.gameObject.SetActive(false);
    }

    // Load the next level of the game from the start menu
    public void Load_Level()
    {
    	// Load test scene
    	MusicManager.GetInstance().SwitchMode(MusicType.AMBIENT);
    	SceneManager.LoadScene("Assets/Scenes/chrisTesting.unity");
    }

    // Toggle visibility of Main_Panel
   	public void Toggle_Main()
   	{
   		Main_Panel.gameObject.SetActive(!Main_Panel.gameObject.activeSelf);
   	}

   	// Toggle visibility of Settings_Panel
   	public void Toggle_Settings()
   	{
   		Settings_Panel.gameObject.SetActive(!Settings_Panel.gameObject.activeSelf);
   	}

   	// Toggle visibility of Credits_Panel
   	public void Toggle_Credits()
   	{
   		Credits_Panel.gameObject.SetActive(!Credits_Panel.gameObject.activeSelf);
   	}

   	// ends the game, no saving
   	public void Quit_Game()
   	{
   		 Application.Quit();
   	}
}
