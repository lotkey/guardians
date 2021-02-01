using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    #region KeyCodes
    KeyCode UP = KeyCode.W;
    KeyCode DOWN = KeyCode.S;
    KeyCode LEFT = KeyCode.A;
    KeyCode RIGHT = KeyCode.D;
    KeyCode DASH = KeyCode.LeftShift;
    #endregion

    private void Update()
    {
        if (Input.GetKey(UP))
        {
            player.movement.MoveUp();
        }        
        
        if (Input.GetKey(DOWN))
        {
            player.movement.MoveDown();
        }
        
        if (Input.GetKeyUp(UP) || Input.GetKeyUp(DOWN))
        {
            player.movement.StopVertical();
        }

        if (Input.GetKey(RIGHT))
        {
            player.movement.MoveRight();
        }
        
        if (Input.GetKey(LEFT))
        {
            player.movement.MoveLeft();
        }
        
        if (Input.GetKeyUp(RIGHT) || Input.GetKeyUp(LEFT))
        {
            player.movement.StopHorizontal();
        }

        if (Input.GetKeyDown(DASH))
        {
            player.movement.Dash();
        }
    }
}
