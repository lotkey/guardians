using UnityEngine;

public class EntityCombat : MonoBehaviour
{
    public Weapon weapon;
    public Entity entity;
    public float attackDamage = 10;
    protected float health = 100;
    protected float maxHealth = 100;

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
