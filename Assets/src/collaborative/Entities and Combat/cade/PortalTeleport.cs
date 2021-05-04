using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTeleport : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        MusicManager.GetInstance().SwitchMode(MusicType.BOSS);
    	SceneManager.LoadScene("Assets/Scenes/Boss.unity");
    }
}
