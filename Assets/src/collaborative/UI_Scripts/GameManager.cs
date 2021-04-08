using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }
    public AudioLowPassFilter lpf;

    public enum State {WIN=0, LOSS=1};

    private void Awake(){
        lpf = FindObjectOfType<Camera>().gameObject.AddComponent<AudioLowPassFilter>();
        lpf.cutoffFrequency = 1200;
        lpf.enabled = false;
    	if(Instance != null){
    		Destroy(this.gameObject); // prevent duplication
    	}

 		Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
	{
		if (Input.GetKeyDown("escape"))
		{
             TogglePauseGame();
        }
	}

    public void Exit()
    {
    	Application.Quit();
    }

    public void TogglePauseGame()
    {
    	// pause time toggle
    	if(Time.timeScale != 0f)
    	{ 
    		Time.timeScale = 0f;
            lpf.enabled = true;
    		Debug.Log("paused time");
    	}else
    	{
    		Time.timeScale = 1f;
            lpf.enabled = false;
    		Debug.Log("unpaused time");
    	}

    	// Open the pause menu in UIManager
    	GUIManager.Instance.TogglePauseMenu();
    }

    public void GameOver(State gameState = State.LOSS)
    {
    	Time.timeScale = 0f;

    	// TODO: do stuff to clean up game, show winning message, etc
        if(gameState == State.LOSS)
        {
            HUDManager.Instance.LostGame();

        }else{
            HUDManager.Instance.WonGame();

        }
    }

    public void Restart()
    {
    	// go to main menu
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("MainMenu");
    }

    public void SetDifficulty(int diff)
    {
        // TODO: set for Dr. BC mode or regular
    }
}
