using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    public GameObject Boss;

    void Update()
    {
        if(Time.time > 10) {
        	// TODO: fix this so it doesn't call literally every update
           if(Boss == null) HUDManager.Instance.WonGame();
        }
    }
}
