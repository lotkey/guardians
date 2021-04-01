using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }

    public enum State {WIN, LOSS};

    private void Awake(){
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
        AudioLowPassFilter lpf = Camera.main.GetComponent<AudioLowPassFilter>();
    	// pause time toggle
    	if(Time.timeScale != 0f)
    	{ 
    		Time.timeScale = 0f;
            lpf.cutoffFrequency = 1200;
    		Debug.Log("paused time");
    	}else
    	{
    		Time.timeScale = 1f;
            lpf.cutoffFrequency = 22000;
    		Debug.Log("unpaused time");
    	}

    	// Open the pause menu in UIManager
    	GUIManager.Instance.TogglePauseMenu();
    }

    public void GameOver(State gameState = State.LOSS)
    {
    	Time.timeScale = 0f;

    	// TODO: do stuff to clean up game, show winning message, etc
    }

    public void Restart()
    {
    	// reload the scene I guess
    	Debug.Log("reload the scene");
    	Time.timeScale = 1f;
    	//SceneManager.LoadScene("Main_Game");
    }

    public void SetDifficulty(int diff)
    {
        // TODO: set for Dr. BC mode or regular
    }
}
