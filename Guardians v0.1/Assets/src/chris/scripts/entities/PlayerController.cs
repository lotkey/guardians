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
    #endregion
    private void Update()
    {
        if (Input.GetKey(UP))
        {
            player.movement.MoveUp();
        }        
        else if (Input.GetKey(DOWN))
        {
            player.movement.MoveDown();
        }
        else
        {
            player.movement.StopVertical();
        }

        if (Input.GetKey(RIGHT))
        {
            player.movement.MoveRight();
        }
        else if (Input.GetKey(LEFT))
        {
            player.movement.MoveLeft();
        }
        else
        {
            player.movement.StopHorizontal();
        }
    }
}
