using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    protected float dashCooldownLength = .5f;
    protected float dashCooldownTimeEnd = 0f;

    private void Update()
    {
        Vector2 timeElapsed = new Vector2(Time.time - timeSinceMovedHorizontally, Time.time - timeSinceMovedVertically);
        if (timeElapsed.x > Time.deltaTime && timeElapsed.x > Time.fixedDeltaTime &&
            timeElapsed.y > Time.deltaTime && timeElapsed.y > Time.fixedDeltaTime)
        {
            isMoving = false;
        }
    }

    /*public override bool Dash()
    {
        if (Time.time > dashCooldownTimeEnd)
        {
            float directionDegrees = entity.movement.DirectionFacingDegrees() - 90;
            Vector2 direction = new Vector2(Mathf.Cos(directionDegrees), Mathf.Sin(directionDegrees));
            entity.body.AddForce(direction * .01f);
            Debug.Log("Player dash.");
            return true;
        }
        else
        {
            return false;
        }
    }*/
}