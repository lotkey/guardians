using UnityEngine;


//Subclass of Weapon, Gun weapon
public class GunWeapon : Weapon
{
    //Variable declarations
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
    public float bulletSpeed;

    //Declarations of Classes being used
    public Bullet bullet;
    public Transform bulletSpawn;

    //Overriden Attack(): Dynamically bound Attack function (Polymorphic) 
    public override bool Attack()
    {
        //Runs this when time ran does not exceed specified time
        //A cooldown time for strikes
        if (Time.time > cooldownTimeEnd)
        {
            //Creates new instantiation of bullet as long as Attack is being called
            //Produces a certain number of bullets per call of Attack()
            for (int i = 0; i < numberOfBulletsProduced; i++)
            {
                //Instantiate, SetDirection of bullet and make sound (SoundManager)
                Bullet newBullet = Instantiate(bullet, bulletSpawn.position, wielder.transform.rotation);
                newBullet.SetDirection(wielder.movement.DirectionFacingVector());
                SoundManager.GetInstance().Play("gunshot");
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        //If time isn't right do nothing.
        return false;
    }
}