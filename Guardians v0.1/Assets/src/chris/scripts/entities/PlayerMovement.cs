using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : EntityMovement
{
    public void Dash()
    {
        entity.body.AddForce(new Vector2(facing.x * entity.speed * 500, facing.y * entity.speed * 500));
    }
}
