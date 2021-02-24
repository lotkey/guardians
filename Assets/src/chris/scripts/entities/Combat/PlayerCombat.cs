using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public Weapon weapon;
    public override void Attack()
    {
        weapon.Attack();
    }

    public override void Die()
    {
        // Reload the scene?
    }
}