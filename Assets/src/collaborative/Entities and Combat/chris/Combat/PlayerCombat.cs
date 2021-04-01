using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    private float invincibilityCooldown;
    private float invincibilityCooldownEndTime = 0f;
    public override void Attack()
    {
        if (weapon != null)
        {
            bool success = weapon.Attack();
            if (success) entity.mainAnimator.PlayMeleeAttackAnimation();
        }
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
            entity.mainAnimator.PlayHurtAnimation();

            // TODO: fix the HUDManager Singleton
            //GameObject.Find("HUD_Canvas").GetComponent<HUDManager>().SetHP((int)health);
            HUDManager.Instance.SetHP((int)health);
        }
        else
        {
            Debug.Log("Player is in invincibility cooldown...");
        }
    }
}