using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : EntityCombat
{
    public override void Attack()
    {
        /*
        if (attack style is melee) }
            deal damage to all enemies in the weapons range
        }
        else {
            shoot the weapon in the player's gaze direction
        }
         */
    }

    public override void Die()
    {
        // Reload the scene?
    }
}