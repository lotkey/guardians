using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{ get; private set; }
    public AudioLowPassFilter lpf;
    public MusicManager musicManager;

    public float nextWaveTime = 300;
    public int timeBetweenWaves = 300; // time in seconds
    public int numberOfWaves = 3;
    private int currentWave = 0;
    public int sectionsPerWaves = 5;
    private int currentSection = 0;
    public int numberOfEnemiesFirstSection = 10;
    public float rateOfEnemyIncrease = 1.1f; // 1 means the number of enemies doesn't increase each section, 2 means it doubles, 0.5f means it halves
    public GameObject[] enemyPrefabs = null;
    public GameObject Portal;
    private bool WAVE = false;
    private List<GameObject> waveEnemies = new List<GameObject>();
    public Transform[] spawnpoints;

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

    private void Start()
    {
        if (Portal) Portal.gameObject.SetActive(false);
        musicManager = MusicManager.GetInstance();
    }

    private void Update()
	{
        /*if (!WAVE && musicManager.GetCurrentMode() == MusicType.WAVE)
        {
            musicManager.SwitchMode(MusicType.AMBIENT);
        }*/
        HUDManager.Instance.SetClockUI(TimeUntilNextWave());

        if (!WAVE && Time.time >= nextWaveTime && SceneManager.GetActiveScene().name == "chrisTesting" && currentWave < numberOfWaves)
        {
            WAVE = true;
            Debug.Log("Time for wave to start!");
            musicManager.SwitchMode(MusicType.WAVE);
            currentSection = 0;
            SpawnSectionOfWave();
        }
        else if (WAVE && waveEnemies.Count > 0)
        {
            bool enemiesDefeated = true;
            for (int i = 0; i < waveEnemies.Count; i++)
            {
                if (waveEnemies[i] != null) enemiesDefeated = false;
            }

            if (enemiesDefeated && currentSection < sectionsPerWaves && SceneManager.GetActiveScene().name == "chrisTesting")
            {
                waveEnemies.Clear();
                currentSection++;
                SpawnSectionOfWave();
            }
            else if (enemiesDefeated)
            {
                WAVE = false;
                currentWave++;
                // TODO: CADE/MICHAEL/RYAN Spawn the portal in this if statement
                if (currentWave == numberOfWaves) Portal.gameObject.SetActive(true);
                musicManager.SwitchMode(MusicType.AMBIENT);
                nextWaveTime = Time.time + timeBetweenWaves;
            }
        }

		if (Input.GetKeyDown("escape"))
		{
             TogglePauseGame();
        }
	}

    private void SpawnSectionOfWave()
    {
        for (int i = 0; i < (numberOfEnemiesFirstSection * Mathf.Pow(rateOfEnemyIncrease, currentSection)); i++)
        {
            int randomIndex = (int)(Random.value * enemyPrefabs.Length);
            int index = (int)(Random.value * spawnpoints.Length);
            Vector3 randomPosition = spawnpoints[index].position;
            randomPosition.x += (Random.value * 2 - 1) * 5;
            randomPosition.y += (Random.value * 2 - 1) * 5;
            waveEnemies.Add(Instantiate(enemyPrefabs[randomIndex], randomPosition, transform.rotation));
            Debug.Log($"{randomIndex}");
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

    // closes the application
    public void Exit()
    {
    	Application.Quit();
    }

    // switches the state of the game, primarily changes the time scale
    public void TogglePauseGame()
    {
        if(lpf == null)
        {
            lpf = FindObjectOfType<Camera>().gameObject.GetComponent<AudioLowPassFilter>();
            if (lpf == null)
            {
                lpf = FindObjectOfType<Camera>().gameObject.AddComponent<AudioLowPassFilter>();
            }
            lpf.cutoffFrequency = 1200;
            lpf.enabled = false;
        }

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

    // Call post game setup once the player has died
    public void GameOver(State gameState = State.LOSS)
    {
        MusicManager.GetInstance().SwitchMode(MusicType.MAINMENU);
    	Time.timeScale = 0f;

        if(gameState == State.LOSS)
        {
            HUDManager.Instance.LostGame();

        }else{
            HUDManager.Instance.WonGame();
        }
    }

    // go back to the main menu on death
    public void Restart()
    {
        HUDManager.Instance.ClearEndGameMSG();

    	// go to main menu
    	Time.timeScale = 1f;
    	SceneManager.LoadScene("MainMenu");
    }

    public void SetActiveBCMode(bool diff)
    {
        // set for Dr. BC mode or regular
        Player.GetPlayer().combat.SetInvincible(diff); 
        if (NexusEntity.GetInstance()) NexusEntity.GetInstance().combat.SetInvincible(diff);
    }
}
