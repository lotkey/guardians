using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    private float vertical;
    private float horizontal;
    private bool attack;
    private bool attackHold;
    private bool dash;
    private Vector2 mousePos;
    public float dodgeCooldown = 5f;
    private float dodgeCooldownEnd = 0f;
    private float scrollWheel = 0;
    public Inventory inventory;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            vertical = Input.GetAxisRaw("Vertical");
            horizontal = Input.GetAxisRaw("Horizontal");
            scrollWheel = Input.GetAxisRaw("Mouse ScrollWheel");
            mousePos = Input.mousePosition;

            if (!attack) attack = Input.GetKeyDown(KeyCode.Mouse0);
            if (!attackHold) attackHold = Input.GetKey(KeyCode.Mouse0);

            if (scrollWheel < 0)
            {
                inventory.EquipNext();
                Debug.Log("Scroll wheel > 0");
                attack = false;
            }
            else if (scrollWheel > 0)
            {
                inventory.EquipPrevious();
                Debug.Log("Scroll wheel < 0");
                attack = false;
            }

            if (!dash && Time.time >= dodgeCooldownEnd && Input.GetKeyDown(KeyCode.LeftShift))
            {
                dash = true;
                dodgeCooldownEnd = Time.time + dodgeCooldown;
            }
        }
    }

    private void FixedUpdate()
    {
        Weapon weapon = inventory.GetEquipped();
        player.movement.Move(horizontal, vertical, Time.fixedDeltaTime);
        if (weapon)
        {
            if (weapon.fireType == FireType.AUTOMATIC)
            {
                if (attackHold) player.combat.Attack();
                attackHold = false;
            }
            else
            {
                if (attack) player.combat.Attack();
                attack = false;
            }

            if (dash)
            {
                player.movement.Dash();
                dash = false;
            }
        }
        RotatePlayer();
    }

    private void RotatePlayer()
    {
        Vector2 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 newMousePos = new Vector2();
        newMousePos.x = mousePos.x - playerScreenPosition.x;
        newMousePos.y = mousePos.y - playerScreenPosition.y;

        float angle = Mathf.Atan2(newMousePos.y, newMousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
