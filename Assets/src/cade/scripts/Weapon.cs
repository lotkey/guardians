using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    protected Entity wielder;
    public WeaponType weaponType;
    protected float cooldownTimeAmount = 0f;
    protected float cooldownTimeEnd = 0f;
    
    public virtual bool Attack()
    {
        return true;
    }
}

public enum WeaponType
{
    MELEE = 0,
    GUN = 1
}