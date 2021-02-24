using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public Weapon weapon;
    public override void Attack()
    {
        if (weapon != null) weapon.Attack();
    }

    public override void Die()
    {
        // Reload the scene?
    }
}