using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RespawnUI : MonoBehaviour
{
	public List<string> nexusLines = new List<string>();
	private Text clock;
	public float initialTime = 15f;
	private float clockTime;
	private bool runClock = false;

	public void init()
	{
		this.transform.GetChild(1).gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = nexusLines[(int)(Random.value * nexusLines.Count)];
		clockTime = initialTime;
		clock = this.GetComponentInChildren<Text>();
		Time.timeScale = 0f; // pause game so enemies don't pounce on player
		clock.text = clockTime.ToString("F1");
		runClock = true;
	}

    // Update is called once per frame
    void Update()
    {
        if(runClock && clockTime > 0)
        {
        	Debug.Log("clockTime = " + clockTime);
        	clockTime -= Time.fixedUnscaledDeltaTime;
        	clock.text = clockTime.ToString("F0");
        }else if(clockTime <= 0){
        	Time.timeScale = 1f; // renable the game
        	this.gameObject.SetActive(false);
        }
    }
}
