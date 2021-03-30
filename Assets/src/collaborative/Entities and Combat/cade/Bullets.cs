using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float damage;
    public float speed;
    public Vector2 direction;
    public Rigidbody2D body;
    public Player player;


    public Transform bullet;
    public float rad = 0.4f;
    public bool collision = false;
    public LayerMask wall;



    public Bullets(Vector2 direction, float speed, float damage)
    {
        this.speed = speed;
        this.direction = direction;
        this.damage = damage;
    }

    private void Start()
    {
        player = FindObjectOfType<Player>();
        body.velocity = direction * speed;
        // set the rotation of the bullet image
    }

    private void Update()
    {
        collided = Physics2D.OverlapCircle(bullet.position,rad,wall);

        if(collided) Destroy(gameObject);
        if(getComponent<Renderer>().isVisible) Destroy(gameObject);
        // if its too far from player then Destroy(this)
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
