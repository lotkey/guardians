using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Boss : Enemy
{

    // This function is used for reseting the default values from the superclass
    public void Reset() {
        //combat.attackDamage = 35f;    // default amount
        //combat.SetMaxHealth(1300f);   // default amount
        //movement.speed = 3f;     // default amount // This is irrelevant now with A*
    }
    
    // Start is called before the first frame update
    new void Start() {
        //base.Start();  // calls the Start() method in the parent class
        anim = GetComponent<Animator>();

        aiDest = gameObject.GetComponent<AIDestinationSetter>();
        player = FindObjectOfType<Player>().transform;
        aiDest.target = player;
    }

    // Update is called once per frame
    new void Update() {
        //base.Update();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            Entity Player = other.gameObject.GetComponent<Entity>();

            Player.combat.TakeDamage(combat.attackDamage);  //lowers players health by the amount of attack this enemy does
            //Player.health -= attackDamage;

            print("OUCH: Player hurt by Brute.\n" + "Player health = " + Player.combat.GetHealth() + "\n");
        
            
        }
        else if (other.CompareTag("Nexus")) {
            NexusEntity nexus = NexusEntity.GetInstance(); //will get you the instance of the Nexus

            // then you can do nexus.TakeDamage(___) like normal combat scripts
            nexus.combat.TakeDamage(combat.attackDamage);

            print("Nexus hurt by Brute.\n" + "Nexus health = " + nexus.combat.GetHealth() + "\n");
        }
    }
}
