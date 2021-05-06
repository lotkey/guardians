using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoomManager : MonoBehaviour
{
    public GameObject Boss;

    private int haventWon = 1;

    void Update()
    {
        if( (haventWon == 1) && (Time.time > 10) ) 
        {
            if(Boss == null) 
            {
                HUDManager.Instance.WonGame();
                haventWon = 0; // hopefully won't call every update now.
            }            
        }
    }
}
