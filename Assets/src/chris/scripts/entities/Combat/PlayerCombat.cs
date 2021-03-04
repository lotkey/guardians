using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public Weapon weapon;
    public float invincibilityCooldown;
    public float invincibilityCooldownEndTime = 0f;
    public override void Attack()
    {
        if (weapon != null) weapon.Attack();
    }

    public override void Die()
    {
        // Respawn player
    }

    public override void TakeDamage(float damage)
    {
        if (Time.time > invincibilityCooldownEndTime)
        {
            // Subtract damage from the health and Die if the health is below 0
            health -= damage;
            if (health <= 0) Die();
            invincibilityCooldownEndTime = Time.time + invincibilityCooldown;
        }
        else
        {
            Debug.Log("Player is in invincibility cooldown...");
        }
    }
}