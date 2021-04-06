using UnityEngine;

public class NexusCombat : EntityCombat
{
    private float invincibilityCooldown;
    private float invincibilityCooldownEndTime = 0f;

    public override void Die()
    {
        // Game lost
    }

    public override void TakeDamage(float damage)
    {
        if (Time.time > invincibilityCooldownEndTime)
        {
            // Subtract damage from the health and Die if the health is below 0
            health -= damage;
            if (health <= 0) Die();
            invincibilityCooldownEndTime = Time.time + invincibilityCooldown;
            // entity.mainAnimator.PlayHurtAnimation(); No Nexus animations yet (maybe never)
        }
        else
        {
            Debug.Log("Nexus is in invincibility cooldown...");
        }
    }
}