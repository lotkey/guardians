using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.TogglePauseGame(); // toggle when script enters the scene
    }

    // Update is called once per frame
    void Update()
    {

    }

    // call this to pause toggle pause from this script
    public void Exit()
    {
    	GameManager.Instance.TogglePauseGame();
    }
}
