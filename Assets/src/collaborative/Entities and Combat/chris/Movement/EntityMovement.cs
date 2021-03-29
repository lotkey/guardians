using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public Entity entity;
    private float timeSinceMovedVertically = 0f;
    private float timeSinceMovedHorizontally = 0f;
    private bool isMoving;
    public float speed = 5;

    private void Update()
    {
        Vector2 timeElapsed = new Vector2(Time.time - timeSinceMovedHorizontally, Time.time - timeSinceMovedVertically);
        if(timeElapsed.x > Time.deltaTime && timeElapsed.x > Time.fixedDeltaTime &&
            timeElapsed.y > Time.deltaTime && timeElapsed.y > Time.fixedDeltaTime)
        {
            isMoving = false;
        }
    }

    public void Move(float x, float y, float deltaTime)
    {
        entity.body.position += new Vector2(x * deltaTime * speed, y * deltaTime * speed);
        if (!(x == 0 && y == 0))
        {
            if (x != 0)
            {
                timeSinceMovedHorizontally = Time.time;
                isMoving = true;
            }
            if (y != 0)
            {
                timeSinceMovedVertically = Time.time;
                isMoving = true;
            }
        }
    }

    public void MoveX(float x, float deltaTime)
    {        
        entity.body.position += new Vector2(x * deltaTime * speed, 0);
    }

    public void MoveY(float y, float deltaTime)
    {
        entity.body.position += new Vector2(0, y * deltaTime * speed);
    }

    public virtual void Dash()
    {
        /* Base function for dash. Does nothing. Use 'override' to add dashing ability to children classes
        public override void Dash() {
            // do something
        }
         */
    }

    public bool IsMoving()
    {
        return isMoving;
    }

    public float DirectionFacingDegrees()
    {
        /* Returns a float between [0, 270]
         *   with 0 degrees meaning that the entity is facing to the right,
         *   90 degrees meaning that the entity is facing up,
         *   270 degrees meaning that the entity is facing down, etc.
         */
        return transform.rotation.eulerAngles.z;
    }

    public Vector2 DirectionFacingVector()
    {

        return new Vector2();
    }
}
