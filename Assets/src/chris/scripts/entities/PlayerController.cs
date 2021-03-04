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
    Vector2 mousePos;

    private void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        mousePos = Input.mousePosition;
        if (!attack)
        {
            attack = Input.GetKeyDown(KeyCode.Mouse0);
        }

        // for testing the music manager
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MusicManager musicManager = FindObjectOfType<MusicManager>();
            if (musicManager.CurrentMode() != MusicType.AMBIENT)
            {
                musicManager.SwitchMode(MusicType.AMBIENT);
            }
            else
            {
                musicManager.SwitchMode(MusicType.WAVE);
            }
        }
        //
    }

    private void FixedUpdate()
    {
        player.movement.Move(horizontal, vertical, Time.fixedDeltaTime);
        if (attack)
        {
            player.combat.Attack();
            attack = false;
        }
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x -= playerScreenPosition.x;
        mousePos.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
