using UnityEngine;

public class MeleeWeapon : Weapon
{
    public float attackRange = 1f;
    // attack width?
    public float attackDamage = 1f;
    public LayerMask opponentLayer;

    public override bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(wielder.transform.position, attackRange, opponentLayer);
            foreach (Collider2D enemy in enemies)
            {
                Entity entity = enemy.GetComponent<Entity>();
                if (entity != null)
                {
                    entity.combat.TakeDamage(attackDamage);
                    Debug.Log($"Entity {entity} was hurt! ouch");
                }
            }
            cooldownTimeEnd = cooldownTimeAmount + Time.time;
            return true;
        }
        return false;
    }
}

public enum MeleeWeaponType
{
    //SWORD = 0,
    //AXE = 1
}