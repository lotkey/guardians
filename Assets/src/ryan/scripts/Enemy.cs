using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
//RDR

//abstract class for an enemy
public abstract class Enemy : Entity
{             
    protected AIDestinationSetter aiDest;

    protected Transform player;
    protected Transform nexus;

    public float boundary = 8f;   

    // This function is used for reseting the default values from the superclass
    /*
    public void Reset() {
        attackDamage = 10f;    // default amount
        health = 100f;   // default amount
        speed = 10f;     // default amount
    }*/

    //public PlayerHealth playerHealth;  //this is for dealing damage to a player's health
    public Animator anim;

    // Start is called before the first frame update
    public void Start()
    {
        //playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();

        aiDest = gameObject.GetComponent<AIDestinationSetter>();
        player = FindObjectOfType<Player>().transform;
        if (NexusEntity.GetInstance() != null) nexus = NexusEntity.GetInstance().transform;

        if (Vector3.Distance(transform.position, player.position) > boundary){//true if distance from player is greater than boundary variable
            aiDest.target = nexus;
        } else {
            aiDest.target = player;
        }
    }

    // Update is called once per frame
    
    public void Update()
    {
        if(aiDest.target == player){
            if (Vector3.Distance(transform.position, aiDest.target.position) > boundary){//true if distance from player is greater than boundary
                aiDest.target = nexus;
            }
        } 
        else if(aiDest.target == nexus){
            if (Vector3.Distance(transform.position, player.position) < boundary){//true if distance from player is less than boundary variable
                aiDest.target = player;
            }

        }
    }
    
}
