using UnityEngine;

public class NexusCombat : EntityCombat
{
    private float invincibilityCooldown;
    private float invincibilityCooldownEndTime = 0f;

    public override void Die()
    {
        // Game lost
        GameManager.Instance.GameOver(GameManager.State.LOSS);
    }

    public override void TakeDamage(float damage)
    {
        if (!isInvincible)
        {
            if (Time.time > invincibilityCooldownEndTime)
            {
                // Subtract damage from the health and Die if the health is below 0
                health -= damage;
                if (health <= 0) 
                {
                    Die();
                }else{
                    // hupdate HUD
                    HUDManager.Instance.SetNexusHealth((int)health);
                }

                invincibilityCooldownEndTime = Time.time + invincibilityCooldown;
                // entity.mainAnimator.PlayHurtAnimation(); No Nexus animations yet (maybe never)
            }
            else
            {
                Debug.Log("Nexus is in invincibility cooldown...");
            }
        }
    }
}