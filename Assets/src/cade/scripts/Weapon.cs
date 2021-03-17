using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Entity wielder;
    public WeaponType weaponType;
    public float cooldownTimeAmount = 0f;
    public float cooldownTimeEnd = 0f;
    
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