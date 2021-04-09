using UnityEngine;

public class GunWeapon : Weapon
{
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
    public float bulletSpeed;
    public float bulletDamage;
    public Bullet bullt;
    public GameObject gObject;


    public override bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            for (int i = 0; i < numberOfBulletsProduced; i++)
            {
                Instantiate(bullt,gObject.transform.position,transform.rotation);
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        return false;
    }
}