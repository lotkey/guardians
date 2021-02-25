using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMenuManager : MonoBehaviour
{
	private GameObject SPanel; // settings panel

    // Start is called before the first frame update
    void Start()
    {
        SPanel = this.transform.GetChild(2).gameObject;
        if(SPanel == null)
        {
        	Debug.LogError("no reference to Settings Panel found");
        }else{
        	SPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Toggle the active state of the settings panel
    public void ToggleSettings()
    {
    	SPanel.SetActive(!SPanel.activeSelf);
    }

    // End game through game manager
    public void Quit()
    {
    	//TODO: quit the game by calling the game manager quit function
    	Debug.Log("Quit the game");
    }

    // Unpause the game through game manager
    public void Resume()
    {
    	//TODO: resume the game aka unpause
    	Debug.Log("Unpause the game");
    }

}
