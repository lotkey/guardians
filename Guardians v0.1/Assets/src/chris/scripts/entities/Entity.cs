using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body;

    // Movement
    public EntityMovement movement;
    public float speed;

    // Combat
    public float attackDamage;
    public float health;
    public float maxHealth;

    // Animations
    // public Animator animator;
}
