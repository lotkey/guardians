using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    private float invincibilityCooldown;
    private float invincibilityCooldownEndTime = 0f;
    private Vector2 respawnPoint;

    private void Awake()
    {
        respawnPoint = transform.position;
    }

    public override void Attack()
    {
        if (weapon != null)
        {
            bool success = weapon.Attack();
            if (success)
            {
                entity.mainAnimator.PlayMeleeAttackAnimation();
                Player.GetPlayer().playerArmsAnimator.PlayAttackAnimation();
            }
        }
    }

    public override void Die()
    {
        // Reset inventory
        transform.position = respawnPoint;
        Heal(maxHealth * .7f);
        GameManager.Instance.GameOver(0);
    }

    public override void Heal(float healAmount)
    {
        // Heal the entity but not above its maxHealth
        health = (maxHealth >= health + healAmount)
            ? health + healAmount
            : maxHealth;

        HUDManager.Instance.SetHP((int)health);
    }

    public override void TakeDamage(float damage)
    {
        if (Time.time > invincibilityCooldownEndTime)
        {
            // Subtract damage from the health and Die if the health is below 0
            health -= damage;
            if (health <= 0) Die();
            invincibilityCooldownEndTime = Time.time + invincibilityCooldown;
            Player.GetPlayer().playerArmsAnimator.PlayHurtAnimation();
            entity.mainAnimator.PlayHurtAnimation();

            HUDManager.Instance.SetHP((int)health);
        }
        else
        {
            Debug.Log("Player is in invincibility cooldown...");
        }
    }
}