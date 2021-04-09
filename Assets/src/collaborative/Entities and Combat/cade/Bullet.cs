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

    public Bullet(Vector2 direction, float speed, float damage)
    {
        //Set speed, direction and damage
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
    }

    private void Start()
    {
        //Adds rigidbody to gameObject
        body = gameObject.GetComponent<Rigidbody2D>();
        if (body == null) body = gameObject.AddComponent<Rigidbody2D>();
        //Gets player
        Player.GetPlayer();
        //Set velocity
        //body.velocity = direction * speed;
        //Set rotation of bullet
        transform.rotation = Quaternion.Euler(direction);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Entity>() != null)
        {
            collision.gameObject.GetComponent<Entity>().combat.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
