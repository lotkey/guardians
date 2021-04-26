using UnityEngine;
using System.Collections.Generic;


//Weapon Parent Class (Function/variable Declarations)
public class Weapon : MonoBehaviour
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
<<<<<<< Updated upstream
    public WeaponIconType iconType;
    public Sprite icon;

    //Variable declarations
=======
    public WeaponIconType iconType; // icon identifier
    public Sprite icon; // inventory icon
>>>>>>> Stashed changes
    public float attackDamage = 1f;
    public float cooldownTimeAmount = 0f;
    public float cooldownTimeEnd = 0f;

    private void Awake()
    {
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
            default:
                icon = Resources.Load<Sprite>("sprites/chris/weaponIcons/shotgun");
                break;
        }
    }

    //Parent virtual method: Null object pattern
    public virtual bool Attack()
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
    AUTOMATIC_RIFLE = 2
}