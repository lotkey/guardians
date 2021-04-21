using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Bullet class for instantiating bullets
public class Bullet : MonoBehaviour
{
    //Variable declarations
    public float damage;
    public float speed;
    public Vector2 direction;
    public Rigidbody2D body;
    private Player player;
    public bool collision = false;
    
    //For Stress test. Singleton Pattern
    private static int counter;

    //Constructor (Set default variables and create gameOject)
    public Bullet(Vector2 direction, float speed, float damage)
    {
        //Set speed, direction and damage
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
        
        //Create gameObject for bullet
        body = gameObject.GetComponent<Rigidbody2D>();
        if (body == null) body = gameObject.AddComponent<Rigidbody2D>();
    }

    //Set Direction of bullet using Vector2
    public void SetDirection(Vector2 bulletDirection)
    {
        this.direction = bulletDirection;
        body.velocity = direction * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    //Start function: Called when game first starts
    private void Start()
    {
        //Gets player and Rotation using Quaternion.Euler
        player = Player.GetPlayer();
        transform.rotation = Quaternion.Euler(direction);
    }

    //When trigger is activated (a collider is touched) This function is called
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //For Stress test
        //Debug.Log("Bullets Shot: " + counter);
        //counter+=1;

        //Entity takes damage when Trigger entered
        Entity collider = collision.gameObject.GetComponent<Entity>();
        if (collider && collision.tag!="Nexus")
        {
            collider.combat.TakeDamage(damage);
        }
        //If not an item or entity, destroy bullet
        if(collision.tag!="Pickable")
            Destroy(gameObject);
    }
}
