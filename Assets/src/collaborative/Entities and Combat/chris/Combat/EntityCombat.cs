using UnityEngine;
using UnityEngine.Tilemaps;

public class EntityCombat : MonoBehaviour
{
    //public Weapon weapon;
    public Entity entity;
    public float attackDamage = 10;
    public float health = 100;
    public float maxHealth = 100;
    protected bool died = false;
    public Tile deathTile;
    public Tilemap tilemap;
    public GridLayout gridLayout;
    public Inventory inventory;

    protected bool isInvincible = false;

    // update the weapon slot for this player script
    /*public virtual bool EquipWeapon(Weapon newWeapon)
    {
        Weapon weapon = inventory.GetEquipped();
        weapon = newWeapon;
        return true;
    }*/

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

    public void SetInvincible(bool isInvincible)
    {
        this.isInvincible = isInvincible;
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
        if (!died)
        {
            // Subtract damage from the health and Die if the health is below 0
            if (isInvincible) return;
            health -= damage;
            if (health <= 0)
            {
                died = true;
                Die();
            }
        }
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
        Weapon weapon = inventory.GetEquipped();
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
        Debug.Log("Die()");
        HealthDrop.DropHealth(.2f * maxHealth, transform.position);

        GameObject grid = GameObject.Find("BloodSplatterGrid");
        tilemap = GameObject.Find("BloodSplatters").GetComponent<Tilemap>();
        gridLayout = GameObject.Find("BloodSplatterGrid").GetComponent<GridLayout>();
        Destroy(gameObject);
        if (tilemap != null && deathTile != null && gridLayout != null)
        {
            tilemap.SetTile(gridLayout.WorldToCell(transform.position), deathTile);
        }
    }
}
