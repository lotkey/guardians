using UnityEngine;
using System;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    public Vector2 direction;
    public Rigidbody2D body;

    public Bullet(Vector2 direction, float damage)
    {
        this.direction = direction;
        this.damage = damage;
    }

    private void Start()
    {
        body.velocity = direction * speed;
        // set the rotation of the bullet image
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider>().GetComponent<Entity>() != null)
        {
            collision.GetComponent<Collider>().GetComponent<Entity>().combat.TakeDamage(damage);
        }
        Destroy(this);
    }
}