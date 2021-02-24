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
    public bool attack;

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        if (!attack)
        {
            attack = Input.GetKeyDown(KeyCode.Space);
        }
    }

    private void FixedUpdate()
    {
        player.movement.Move(horizontal, vertical, Time.fixedDeltaTime);
        if (attack)
        {
            player.combat.Attack();
            attack = false;
        }
    }
}
