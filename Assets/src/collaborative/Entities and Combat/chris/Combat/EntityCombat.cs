﻿using UnityEngine;
using UnityEngine.Tilemaps;

public class EntityCombat : MonoBehaviour
{
    public Weapon weapon;
    public Entity entity;
    public float attackDamage = 10;
    public float health = 100;
    public float maxHealth = 100;
    public Tile deathTile;
    public Tilemap tilemap;
    public GridLayout gridLayout;
    //public GameObject healthDropPrefab;

    public void SetMaxHealth(float amount)
    {
        // Set the maximum health to the amount
        // Set the health to the maximum health
        if (amount > 0)
        {
            health = amount;
            maxHealth = amount;
        }
    }

    public float GetHealth()
    {
        // Returns the raw health amount
        return health;
    }

    public float GetNormalizedHealth()
    {
        // Returns a number from 0 to 1 as the percent health
        return health / maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        // Subtract damage from the health and Die if the health is below 0
        health -= damage;
        if (health <= 0) Die();
    }

    public virtual void Heal(float healAmount)
    {
        // Heal the entity but not above its maxHealth
        health = (maxHealth >= health + healAmount) 
            ? health + healAmount 
            : maxHealth;
    }

    public virtual void Attack()
    {
        if (weapon != null)
        {
            bool success = weapon.Attack();
            if (success) entity.mainAnimator.PlayMeleeAttackAnimation();
        }
        else
        {
            Debug.LogWarning("Entity has no weapon to attack with!");
        }
    }

    public virtual void Die()
    {
        /*if (healthDropPrefab != null)
        {
            GameObject healthDropObject = Instantiate(healthDropPrefab, transform);
            healthDropObject.GetComponent<HealthDrop>().healthAmount = maxHealth * .2f;
        }*/
        HealthDrop.DropHealth(.2f * maxHealth, transform.position);
     
        Destroy(entity.gameObject);
        if (tilemap != null && deathTile != null && gridLayout != null)
        {
            tilemap.SetTile(gridLayout.WorldToCell(transform.position), deathTile);
        }
    }
}
