using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Entity wielder;
    public WeaponType weaponType;
    public AmmoType ammoType;
    public FireType fireType;
    public WeaponIconType iconType;
    public Sprite icon;
    public float attackDamage = 1f;
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

public enum AmmoType
{
    NONE = 0,
    SHELL = 1,
    LIGHT = 2,
    MEDIUM = 3,
    HEAVY = 4,
    ROCKET = 5
}

public enum FireType
{
    SINGLE = 0,
    AUTOMATIC = 1
}

public enum WeaponIconType
{
    SWORD = 0,
    SHOTGUN = 0,
    PISTOL = 1,
    AUTOMATIC_RIFLE = 2,
    ROCKET_LAUNCHER = 3
}