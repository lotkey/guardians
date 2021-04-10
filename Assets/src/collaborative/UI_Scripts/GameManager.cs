using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }
    public AudioLowPassFilter lpf;

    public float nextWaveTime = 300;
    public int timeBetweenWaves = 300; // time in seconds
    public int numberOfWaves = 3;
    public int sectionsPerWaves = 5;
    public int numberOfEnemiesFirstSection = 10;
    public float rateOfEnemyIncrease = 1.1f; // 1 means the number of enemies doesn't increase each section, 2 means it doubles, 0.5f means it halves
    public GameObject[] enemyPrefabs = null;

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
        if (Time.time >= nextWaveTime)
        {
            Debug.Log("Time for wave to start!");
        }
		if (Input.GetKeyDown("escape"))
		{
             TogglePauseGame();
        }
	}

    public string TimeUntilNextWaveString()
    {
        return $"{(int)(Time.time - nextWaveTime) / 60}:{(int)(Time.time - nextWaveTime) % 60}";
    }

    public float TimeUntilNextWave()
    {
        return (Time.time > nextWaveTime) ? 0f : (nextWaveTime - Time.time);
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
        // use Player.GetPlayer().combat.SetInvincible(true/false) and Nexus.GetNexus().combat.SetInvincible(true/false)
    }
}
