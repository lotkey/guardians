using UnityEngine;

public class GunWeapon : Weapon
{
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
    public float bulletSpeed;
    public Bullet bullet;
    public Transform bulletSpawn;

    public override bool Attack()
    {
        if (Time.time > cooldownTimeEnd)
        {
            for (int i = 0; i < numberOfBulletsProduced; i++)
            {
                Bullet newBullet = Instantiate(bullet, bulletSpawn.position, wielder.transform.rotation);
                newBullet.SetDirection(wielder.movement.DirectionFacingVector());
                SoundManager.GetInstance().Play("gunshot");
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        return false;
    }
}