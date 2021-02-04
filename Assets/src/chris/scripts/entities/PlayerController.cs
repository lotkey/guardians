using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    [HideInInspector]
    public float vertical;
    [HideInInspector]
    public float horizontal;

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        player.movement.Move(horizontal, vertical, Time.fixedDeltaTime);
    }
}
