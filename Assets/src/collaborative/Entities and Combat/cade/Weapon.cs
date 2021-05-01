using UnityEngine;
using System.Collections.Generic;
using System;

//Weapon Parent Class (Function/variable Declarations)
[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
public class Weapon : ScriptableObject
{
    //Static/Dynamic Binding
    //Weapon w = new MeleeWeapon();
    //w.Attack();
    //MeleeWeapon w = new MeleeWeapon();

    //Class declarations
    public Entity wielder;
    public WeaponType weaponType;
    public AmmoType ammoType;
    public FireType fireType;
    public Sprite weaponSprite;
    public WeaponIconType iconType; // icon identifier
    public Sprite icon; // inventory icon
    public float attackDamage = 1f;
    public float cooldownTimeAmount = 0f;
    [System.NonSerialized] protected float cooldownTimeEnd = 0f;

    private void Awake()
    {
        // Added by Chris during pair programming
        switch(iconType)
        {
            case (WeaponIconType.SWORD):
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/sword");
                break;
            case (WeaponIconType.AUTOMATIC_RIFLE):
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/automatic_rifle");
                break;
            case (WeaponIconType.SHOTGUN):
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/shotgun");
                break;
            case (WeaponIconType.UZI):
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/uzi");
                break;
            case (WeaponIconType.BFSG):
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/BFG");
                break;
            case (WeaponIconType.BFU):
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/BFUzi");
                break;
            default:
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/shotgun");
                break;
        }

    }

    private void Start()
    {
        cooldownTimeEnd = 0;
    }

    //Parent virtual method: Null object pattern
    public virtual bool Attack(Transform position, bool BCmode)
    {
        return true;
    }

    public virtual bool IsMelee()
    {
        return true;
    }

    // convert data into a list of strings that can be used by UI
    public virtual List<string> ToString()
    {
        //TODO: implement
        return null;
    }
}


//Weapon type enumerator (Choose which one)
public enum WeaponType
{
    MELEE = 0,
    GUN = 1
}

//Ammo Type (Choose one)
public enum AmmoType
{
    NONE = 0,
    SHELL = 1,
    LIGHT = 2,
    MEDIUM = 3,
    HEAVY = 4,
    ROCKET = 5
}

//Fire Type (Choose one)
public enum FireType
{
    SINGLE = 0,
    AUTOMATIC = 1
}

//WeaponIconType (Choose one)
public enum WeaponIconType
{
    SWORD = 0,
    SHOTGUN = 1,
    AUTOMATIC_RIFLE = 2,
    UZI = 3,
    BFSG = 4,
    BFU = 5
}