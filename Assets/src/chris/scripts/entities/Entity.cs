using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D body;
    public EntityMovement movement;
    public EntityCombat combat;

    // Movement
    public float speed = 5;

    // Combat
    public float attackDamage = 10;
    public float health = 100;
    public float maxHealth = 100;
}