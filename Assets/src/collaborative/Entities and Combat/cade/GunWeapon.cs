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
    public GameObject bulletPrefab;

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
                case (WeaponSubType.UZI):
                    SoundManager.GetInstance().Play("uzi");
                    break;
                case (WeaponSubType.BFSG):
                    SoundManager.GetInstance().Play("BFSG");
                    break;
                case (WeaponSubType.BFU):
                    SoundManager.GetInstance().Play("BFU");
                    break;
                default:
                    break;
            }

            //Creates new instantiation of bullet as long as Attack is being called
            //Produces a certain number of bullets per call of Attack()
            for (int i = 0; i < numberOfBulletsProduced; i++)
            {
                GameObject b = Instantiate(bulletPrefab);
                Bullet bullet = b.GetComponent<Bullet>();
                if (bullet)
                {
                    if (BCmode) bullet.damage = 10000000;
                    else bullet.damage = attackDamage;
                    (Vector2, float) vectorAngle = RandomFireVectorAngle();
                    Vector2 direction = vectorAngle.Item1;
                    float angle = vectorAngle.Item2;
                    b.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
                    b.transform.position = position.position;
                    bullet.body.velocity = direction * (bulletSpeed + Random.Range(0, .25f));
                }
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

    public (Vector2, float) RandomFireVectorAngle()
    {
        // Added by Chris during pair programming
        if (wielder == null)
        {
            Debug.LogError("wielder is null");
        }
        float angle = wielder.transform.rotation.eulerAngles.z;
        float randomAngle = Random.Range(-bulletSpread / 2.0f, bulletSpread / 2.0f);
        angle += randomAngle;
        Vector2 direction = new Vector2(Mathf.Cos(Mathf.Deg2Rad * angle), Mathf.Sin(Mathf.Deg2Rad * angle));

        return (direction, angle + randomAngle);
    }

    public override bool IsMelee()
    {
        return false;
    }
}