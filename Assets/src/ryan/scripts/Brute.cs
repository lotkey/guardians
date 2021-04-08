using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Brute : Enemy
{

    // This function is used for reseting the default values from the superclass
    public void Reset() {
        combat.attackDamage = 15f;    // default amount
        combat.SetMaxHealth(150f);   // default amount
        movement.speed = 1f;     // default amount // This is irrelevant now with A*
    }
    
    // Start is called before the first frame update
    new void Start() {
        base.Start();  // calls the Start() method in the parent class
    }

    // Update is called once per frame
    new void Update() {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            Entity Player = other.gameObject.GetComponent<Entity>();

            Player.combat.TakeDamage(combat.attackDamage);  //lowers players health by the amount of attack this enemy does
            //Player.health -= attackDamage;

            print("OUCH: Player hurt by Brute.\n" + "Player health = " + Player.combat.GetHealth() + "\n");
        
            
        }
        else if (other.CompareTag("Nexus")) {
            Nexus nexus_tmp = other.gameObject.GetComponent<Nexus>();
            // NexusEntity nexus = NexusEntity.GetInstance() will get you the instance of the Nexus
            // then you can do nexus.TakeDamage(___) like normal combat scripts

            nexus_tmp.health -= combat.attackDamage;

            print("Nexus hurt by Brute.\n" + "Nexus health = " + nexus_tmp.health + "\n");
        }
    }
}
