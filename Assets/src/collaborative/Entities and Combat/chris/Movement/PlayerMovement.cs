using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    public float dashCooldownLength = .5f;
    public float dashLength = .25f;
    protected float dashEnd = 0;
    protected float dashCooldownTimeEnd = 0f;
    protected float defaultSpeed;

    private void Awake()
    {
        defaultSpeed = speed;
    }

    private void Update()
    {
        Vector2 timeElapsed = new Vector2(Time.time - timeSinceMovedHorizontally, Time.time - timeSinceMovedVertically);
        if (timeElapsed.x > Time.deltaTime && timeElapsed.x > Time.fixedDeltaTime &&
            timeElapsed.y > Time.deltaTime && timeElapsed.y > Time.fixedDeltaTime)
        {
            isMoving = false;
        }

        if (Time.time > dashEnd && speed != defaultSpeed)
        {
            speed = defaultSpeed;
        }
    }

    public override bool Dash()
    {
        if (Time.time > dashCooldownTimeEnd)
        {
            Debug.Log("Player dash.");
            speed *= 2;
            dashEnd = Time.time + dashLength; 
            dashCooldownTimeEnd = Time.time + dashCooldownLength;
            return true;
        }
        else
        {
            return false;
        }
    }
}