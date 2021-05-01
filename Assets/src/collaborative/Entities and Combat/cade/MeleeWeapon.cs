using UnityEngine;


//Subclass of Weapon, Melee weapon
public class MeleeWeapon : Weapon
{
    //Default variable declaration
    public float attackRange = 1f;
    public LayerMask opponentLayer;

    //Awake function called first
    private void Awake()
    {
        //Set initial values
        ammoType = AmmoType.NONE;
        fireType = FireType.SINGLE;
    }

    //Overriden Attack(): Dynamically bound Attack function (Polymorphic) 
    public override bool Attack(Transform position, bool BCmode)
    {
        //Runs this when time ran does not exceed specified time
        //A cooldown time for strikes
        if (Time.time > cooldownTimeEnd)
        {
            //Create a collider for enemies
            Collider2D[] enemies = Physics2D.OverlapCircleAll(position.position, attackRange, opponentLayer);
            int numEnemies = 0;
            //Combat, if enemy is in proximity of weapon, then take damage
            foreach (Collider2D enemy in enemies)
            {
                Entity entity = enemy.GetComponent<Entity>();
                if (entity != null)
                {
                    numEnemies++;
                    if (BCmode)
                    {
                        entity.combat.TakeDamage(10000000);
                    }
                    else
                    {
                        entity.combat.TakeDamage(attackDamage);
                    }
                    Debug.Log($"Entity {entity} was hurt! ouch");
                }
            }

            //Sound manager stuff for melee swipe
            if (numEnemies > 0) SoundManager.GetInstance().Play("meleeSwipeSuccess");
            else SoundManager.GetInstance().Play("meleeSwipeFail");
            cooldownTimeEnd = cooldownTimeAmount + Time.time;
            return true;
        }
        //Otherwise do nothing
        return false;
    }
}

//Melee Weapon type (Choose one)
public enum MeleeWeaponType
{
    //SWORD = 0,
    //AXE = 1
}