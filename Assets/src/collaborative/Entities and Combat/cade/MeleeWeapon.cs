using UnityEngine;

public class MeleeWeapon : Weapon
{
    public float attackRange = 1f;
    // attack width?
    public LayerMask opponentLayer;

    private void Awake()
    {
        ammoType = AmmoType.NONE;
        fireType = FireType.SINGLE;
    }

    public override bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(wielder.transform.position, attackRange, opponentLayer);
            int numEnemies = 0;
            foreach (Collider2D enemy in enemies)
            {
                Entity entity = enemy.GetComponent<Entity>();
                if (entity != null)
                {
                    numEnemies++;
                    entity.combat.TakeDamage(attackDamage);
                    Debug.Log($"Entity {entity} was hurt! ouch");
                }
            }
            if (numEnemies > 0) SoundManager.GetInstance().Play("meleeSwipeSuccess");
            else SoundManager.GetInstance().Play("meleeSwipeFail");
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