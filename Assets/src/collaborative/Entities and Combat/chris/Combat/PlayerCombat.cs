using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    private float invincibilityCooldown;
    private float invincibilityCooldownEndTime = 0f;
    private Vector2 respawnPoint;
    public Transform bulletSpawn;

    private void Awake()
    {
        respawnPoint = transform.position;
    }

    // equip a new weapon, override the equip weapon from EntityCombat, and update sprites and stuff on the player
    // object
    /*public override bool EquipWeapon(Weapon newWeapon)
    {
        base.EquipWeapon(newWeapon);
        // update the weapon sprite
        if(this.transform.GetChild(1) != null) 
        {
            Debug.Log("updating sprite for equipped weapon");
            this.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().sprite = newWeapon.weaponSprite; 
            return true;
        }else{
            return false;
        }
    }*/

    public override void Attack()
    {
        Weapon weapon = inventory.GetEquipped();
        if(weapon == null)
        {
            Debug.LogError("no weapon equipped");
        }
        if (weapon != null)
        {
            bool success = weapon.Attack(bulletSpawn, isInvincible);
            if (success)
            {
                if (weapon.IsMelee())
                {
                    entity.mainAnimator.PlayMeleeAttackAnimation();
                }
                else
                {
                    entity.mainAnimator.PlayRangedAttackAnimation();
                }
                if (Player.GetPlayer().playerArmsAnimator) Player.GetPlayer().playerArmsAnimator.PlayAttackAnimation();
            }
        }
    }

    public override void Die()
    {
        // Reset inventory
        transform.position = respawnPoint;
        Heal(maxHealth * .7f);
        // notify HUDManager that player has died
        HUDManager.Instance.Respawn();
    }

    public override void Heal(float healAmount)
    {
        // Heal the entity but not above its maxHealth
        health = (maxHealth >= health + healAmount)
            ? health + healAmount
            : maxHealth;

        // notify HUDManager that player health has changed
        HUDManager.Instance.SetHP((int)health);
    }

    public override void TakeDamage(float damage)
    {
        if (!isInvincible)
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

    private IEnumerator wait(float secs)
    {
        yield return new WaitForSeconds(secs);
    }
}