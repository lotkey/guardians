using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Entity entity;

    public void MoveLeft()
    {
        entity.body.velocity = new Vector2(-entity.speed, entity.body.velocity.y);
    }

    public void MoveRight()
    {
        entity.body.velocity = new Vector2(entity.speed, entity.body.velocity.y);
    }

    public void MoveUp()
    {
        entity.body.velocity = new Vector2(entity.body.velocity.x, entity.speed);
    }

    public void MoveDown()
    {
        entity.body.velocity = new Vector2(entity.body.velocity.x, -entity.speed);
    }

    public void StopVertical()
    {
        entity.body.velocity = new Vector2(entity.body.velocity.x, 0);
    }

    public void StopHorizontal()
    {
        entity.body.velocity = new Vector2(0, entity.body.velocity.y);
    }
}
