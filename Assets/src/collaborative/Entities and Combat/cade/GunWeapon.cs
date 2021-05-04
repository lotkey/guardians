using UnityEngine;

//Subclass of Weapon, Gun weapon
[CreateAssetMenu(fileName = "GunWeapon", menuName = "ScriptableObjects/GunWeapon", order = 1)]
public class GunWeapon : Weapon
{
    //Variable declarations
    public float bulletSpread;
    public int amountOfAmmoUsed;
    public int numberOfBulletsProduced;
    public float bulletSpeed;

    //Declarations of Classes being used
    //public Bullet bullet;
    //public Transform bulletSpawn;

    //Overriden Attack(): Dynamically bound Attack function (Polymorphic) 
    public override bool Attack(Transform position, bool BCmode)
    {
        //Runs this when time ran does not exceed specified time
        //A cooldown time for strikes
        if (Time.time > cooldownTimeEnd)
        {
            // Redone by Chris during pair programming
            switch (subType)
            {
                case (WeaponSubType.AUTOMATIC_RIFLE):
                    SoundManager.GetInstance().Play("gunshot");
                    break;
                case (WeaponSubType.SHOTGUN):
                    SoundManager.GetInstance().Play("shotgun_shot");
                    break;
                default:
                    break;
            }

            //Creates new instantiation of bullet as long as Attack is being called
            //Produces a certain number of bullets per call of Attack()
            for (int i = 0; i < numberOfBulletsProduced; i++)
            {
                GameObject bulletObject = new GameObject();
                Bullet bullet = bulletObject.AddComponent<Bullet>();

                if (BCmode) bullet.damage = 10000000;
                else bullet.damage = attackDamage;

                bullet.body = bulletObject.AddComponent<Rigidbody2D>();
                SpriteRenderer spriteRenderer = bulletObject.AddComponent<SpriteRenderer>();
                CircleCollider2D collider = bulletObject.AddComponent<CircleCollider2D>();

                collider.isTrigger = true;
                collider.radius = .25f;

                spriteRenderer.sprite = Resources.Load<Sprite>("sprites/chris/weaponIcons/bullet");
                spriteRenderer.sortingLayerName = "Entities";
                //spriteRenderer.sortingOrder = 0;

                //bulletObject.transform.rotation = Quaternion.Euler(wielder.movement.DirectionFacingVector());
                Vector2 direction = RandomFireVector();
                bulletObject.transform.rotation = Quaternion.Euler(direction);
                bulletObject.transform.position = position.position;

                bullet.body.gravityScale = 0;
                bullet.body.velocity = direction * (bulletSpeed + Random.Range(0, .25f));
                bullet.body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

                bulletObject.layer = 9;
            }
            cooldownTimeEnd = Time.time + cooldownTimeAmount;
            return true;
        }
        //If time isn't right do nothing.
        return false;
    }

    public Vector2 RandomFireVector()
    {
        // Added by Chris during pair programming
    	if(wielder == null)
    	{
    		Debug.LogError("wielder is null");
    	}
        float angle = wielder.transform.rotation.eulerAngles.z;
        float randomAngle = Random.Range(-bulletSpread / 2.0f, bulletSpread / 2.0f);
        angle += randomAngle;
        Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

        return direction;
    }

    public override bool IsMelee()
    {
        return false;
    }
}