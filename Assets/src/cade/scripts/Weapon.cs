using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldownTimeAmount;
    public float cooldownTimeEnd = 0f;

    public float attackRange = 1f;
    public float attackDamageMultiplier = 1.1f;

    public Entity wielder;
    public Vector2 attackPoint;
    /*
     * Enemy is the LayerMask for the player to use as opponentLayer
     * Player is the LayerMask for the enemies to use as opponentLayer
     */
    public LayerMask opponentLayer;

    public bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(wielder.transform.position, attackRange, opponentLayer);
            foreach (Collider2D enemy in enemies)
            {
                if (enemy.GetComponent<Entity>().combat != null)
                {
                    enemy.GetComponent<Entity>().combat.TakeDamage(wielder.combat.attackDamage * attackDamageMultiplier);
                    Debug.Log($"Hurt {enemy.GetComponent<Entity>()}!");
                }
                else
                {
                    Debug.Log("Enemy has no combat script");
                }
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        Debug.Log("Weapon in cooldown...");
        return false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(wielder.transform.position, attackRange);
    }
}