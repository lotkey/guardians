using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float cooldownLength;
    private float cooldownTimeEnd;

    public float attackRange;
    public float attackDamageMultiplier;

    public Entity wielder;
    public LayerMask entityLayer;

    public bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(wielder.movement.position, attackRange);
            foreach (Collider2D collider in colliders)
            {
                if (collider.GetComponent<Entity>() != wielder) // this means enemies can hurt each other... not ideal
                {
                    collider.GetComponent<Entity>().combat.TakeDamage(wielder.attackDamage * attackDamageMultiplier);
                }
            }
            cooldownTimeEnd = Time.time + cooldownLength;
            return true;
        }
        return false;
    }

    void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(wielder.movement.position, attackRange);
    }
}