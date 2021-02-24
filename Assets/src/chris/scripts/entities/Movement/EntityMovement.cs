using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Entity entity;
    public Vector2 facing = new Vector2(0, -1);
    public float timeSinceMovedVertically = 0f;
    public float timeSinceMovedHorizontally = 0f;

    public void Move(float x, float y, float deltaTime)
    {
        entity.body.position += new Vector2(x * deltaTime * entity.speed, y * deltaTime * entity.speed);
        if (!(x == 0 && y == 0))
        {
            facing.x = (x == 0) ? 0 : (x > 0) ? 1 : -1;
            if (x != 0) timeSinceMovedHorizontally = Time.time;
            facing.y = (y == 0) ? 0 : (y > 0) ? 1 : -1;
            if (y != 0) timeSinceMovedVertically = Time.time;
        }
    }

    public void MoveX(float x, float deltaTime)
    {        
        entity.body.position += new Vector2(x * deltaTime * entity.speed, 0);
        facing.x = (x > 0) ? 1 : -1;
        facing.y = 0;
    }

    public void MoveY(float y, float deltaTime)
    {
        entity.body.position += new Vector2(0, y * deltaTime * entity.speed);
        facing.y = (y > 0) ? 1 : -1;
        facing.x = 0;
    }

    public virtual void Dash()
    {
        /* Base function for dash. Does nothing. Use 'override' to add dashing ability to children classes
        public override void Dash() {
            // do something
        }
         */
    }

    #region Boolean Functions to tell what direction the entity is facing
    public bool IsFacingNorth()
    {
        return facing.x == 0 && facing.y == 1;
    }

    public bool IsFacingEast()
    {
        return facing.x == 1 && facing.y == 0;
    }

    public bool IsFacingSouth()
    {
        return facing.x == 0 && facing.y == -1;
    }

    public bool IsFacingWest()
    {
        return facing.x == -1 && facing.y == 0;
    }

    public bool IsFacingNorthEast()
    {
        return facing.x == 1 && facing.y == 1;
    }

    public bool IsFacingSouthEast()
    {
        return facing.x == 1 && facing.y == -1;
    }

    public bool IsFacingSouthWest()
    {
        return facing.x == -1 && facing.y == -1;
    }

    public bool IsFacingNorthWest()
    {
        return facing.x == -1 && facing.y == -1;
    }
    #endregion
}
