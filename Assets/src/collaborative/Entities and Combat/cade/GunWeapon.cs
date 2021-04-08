using UnityEngine;

public class GunWeapon : Weapon
{
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
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