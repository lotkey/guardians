using UnityEngine;

public class GunWeapon : Weapon
{
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
    public AmmoType ammoType;
    public float bulletSpeed;
    public float bulletDamage;

    public override bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            for (int i = 0; i < numberOfBulletsProduced; i++)
            {
                // float angle =
                // spawn in bullet
                // pass in wielder.transform.rotation
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        return false;
    }
}

public enum AmmoType
{
    SHELL = 0,
    LIGHT = 1,
    MEDIUM = 2,
    HEAVY = 3,
    PLASMA = 4,
    ROCKET = 5
}

public enum GunType
{
    SHOTGUN = 0,
    PISTOL = 1,
    BURST_RIFLE = 2,
    AUTOMATIC_RIFLE = 3,
    PLASMA_SHOTGUN = 4,
    ROCKET_LAUNCHER = 5
}