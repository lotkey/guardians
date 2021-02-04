using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//abstract class for an enemy
public abstract class Enemy : Entity
{
    attakDamage = 10f;    // default amount
    health = 100f;   // default amount
    speed = 10f;     // default amount

    //public PlayerHealth playerHealth;  //this is for dealing damage to a player's health
    public Animator anim;

    // Start is called before the first frame update
    public void Start()
    {
        //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    /*
    void Update()
    {
        
    }
    */
}
