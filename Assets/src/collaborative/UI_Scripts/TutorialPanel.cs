using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.TogglePauseGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Exit()
    {
    	GameManager.Instance.TogglePauseGame();
    }
}
