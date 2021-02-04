using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Entity entity;

    public void Move(float x, float y, float deltaTime)
    {
        MoveX(x, deltaTime);
        MoveY(y, deltaTime);
    }

    public void MoveX(float x, float deltaTime)
    {        
        entity.body.position += new Vector2(x * deltaTime * entity.speed, 0);
    }

    public void MoveY(float y, float deltaTime)
    {
        entity.body.position += new Vector2(0, y * deltaTime * entity.speed);
    }
}
