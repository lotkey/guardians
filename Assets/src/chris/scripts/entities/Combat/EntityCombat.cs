using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCombat : MonoBehaviour
{
    public Entity entity;

    public void TakeDamage(float damage)
    {
        // Subtract damage from the health and Die if the health is below 0
        entity.health -= damage;
        if (entity.health <= 0) Die();
    }

    public void Heal(float health)
    {
        // Heal the entity but not above its maxHealth
        entity.health = (entity.maxHealth < entity.health + health) 
            ? entity.health + health 
            : entity.maxHealth;
    }

    public virtual void Attack()
    {
        // overridden by EnemyCombat and PlayerCombat
    }

    public virtual void Die()
    {
        // Remove the entity from the scene
        // add blood splatter
    }
}
