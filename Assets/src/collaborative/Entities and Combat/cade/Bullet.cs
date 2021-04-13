using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public Vector2 direction;
    public Rigidbody2D body;
    public bool collision = false;
    private Player player;
    private static int counter;
    public Bullet(Vector2 direction, float speed, float damage)
    {
        //Set speed, direction and damage
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
        body = gameObject.GetComponent<Rigidbody2D>();
        if (body == null) body = gameObject.AddComponent<Rigidbody2D>();
    }

    public void SetDirection(Vector2 bulletDirection)
    {
        this.direction = bulletDirection;
        body.velocity = direction * speed;
        transform.rotation = Quaternion.Euler(direction);
    }

    private void Start()
    {
        player = Player.GetPlayer();
        transform.rotation = Quaternion.Euler(direction);
    }

    private void Update()
    {
        if (player != null)
        {
            // check if bullet is too far from player and if so destroy it
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Bullets Shot: " + counter);
        //counter+=1;
        Entity collider = collision.gameObject.GetComponent<Entity>();
        if (collider)
        {
            collider.combat.TakeDamage(damage);
        }
        if(collision.tag!="Pickable")
            Destroy(gameObject);
    }
}
