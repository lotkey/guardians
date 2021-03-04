using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCombat : MonoBehaviour
{
    public Entity entity;
    public float attackDamage = 10;
    public float health = 100;
    public float maxHealth = 100;

    public float GetHealth()
    {
        return health;
    }

    public float GetNormalizedHealth()
    {
        return health / maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        // Subtract damage from the health and Die if the health is below 0
        health -= damage;
        if (health <= 0) Die();
    }

    public void Heal(float healAmount)
    {
        // Heal the entity but not above its maxHealth
        health = (maxHealth < health + healAmount) 
            ? health + healAmount 
            : maxHealth;
    }

    public virtual void Attack()
    {
        // overridden by EnemyCombat and PlayerCombat
    }

    public virtual void Die()
    {
        Destroy(entity.gameObject);
        // Remove the entity from the scene
        // add blood splatter
    }
}
