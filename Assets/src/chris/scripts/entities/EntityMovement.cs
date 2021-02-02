using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Entity entity;
    public Vector2 facing = new Vector2(0, 0);
    public void MoveUp()
    {
        entity.body.velocity = new Vector2(entity.body.velocity.x, entity.speed);
        facing.y = 1;
    }

    public void MoveRight()
    {
        entity.body.velocity = new Vector2(entity.speed, entity.body.velocity.y);
        facing.x = 1;
    }

    public void MoveDown()
    {
        entity.body.velocity = new Vector2(entity.body.velocity.x, -entity.speed);
        facing.y = -1;
    }

    public void MoveLeft()
    {
        entity.body.velocity = new Vector2(-entity.speed, entity.body.velocity.y);
        facing.x = -1;
    }

    public void StopVertical()
    {
        entity.body.velocity = new Vector2(entity.body.velocity.x, 0);
        facing.y = 0;
    }

    public void StopHorizontal()
    {
        entity.body.velocity = new Vector2(0, entity.body.velocity.y);
        facing.x = 0;
    }
}
