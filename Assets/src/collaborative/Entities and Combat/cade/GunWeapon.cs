using UnityEngine;

//Subclass of Weapon, Gun weapon
public class GunWeapon : Weapon
{
    //Variable declarations
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
    public float bulletSpeed;
    public float bulletDamage;

    //Declarations of Classes being used
    //public Bullet bullet;
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
                GameObject bulletObject = new GameObject();
                Bullet bullet = bulletObject.AddComponent<Bullet>();
                bullet.damage = bulletDamage;
                SoundManager.GetInstance().Play("gunshot");

                Rigidbody2D body = bulletObject.AddComponent<Rigidbody2D>();
                SpriteRenderer spriteRenderer = bulletObject.AddComponent<SpriteRenderer>();
                CircleCollider2D collider = bulletObject.AddComponent<CircleCollider2D>();

                body.gravityScale = 0;
                body.velocity = wielder.movement.DirectionFacingVector() * bulletSpeed;

                collider.isTrigger = true;
                collider.radius = .25f;

                spriteRenderer.sprite = Resources.Load<Sprite>("sprites/chris/weaponIcons/bullet");
                spriteRenderer.sortingLayerName = "Entities";
                spriteRenderer.sortingOrder = 0;

                bulletObject.transform.rotation = Quaternion.Euler(wielder.movement.DirectionFacingVector());
                bulletObject.transform.position = bulletSpawn.position;
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        //If time isn't right do nothing.
        return false;
    }
}