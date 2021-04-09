using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
//RDR

// This is the most basic melee enemy in Guardians.
public class Grunt : Enemy
{
    /*
    private AIDestinationSetter aiDest;

    private Transform player;
    private Transform nexus;
    */

    //public float boundary = 8f;

    //public Transform target;//set target from inspector or start()
                            //also can change target while running using update

    // This function is used for reseting the default values from the superclass
    public void Reset() {
        combat.attackDamage = 10f;    // default amount
        combat.SetMaxHealth(100f);   // default amount
        movement.speed = 2f;     // default amount
    }
    // Start is called before the first frame update
    new void Start() {
        base.Start();  // calls the Start() method in the parent class
    }

    // Update is called once per frame
    new void Update() {
        base.Update();
        /*
        //--==-- Begin Movement --==--
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
        
         
        //move towards the player
        if (Vector3.Distance(transform.position,target.position)>0.6f){//move if distance from target is greater than 0.6
            transform.Translate(new Vector3(movement.speed* Time.deltaTime,0,0) );
        }
        //--==-- End Movement --==--
        */

        // change target depending on distance from player.
        
        /*
        if(aiDest.target == player){
            if (Vector3.Distance(transform.position, aiDest.target.position) > boundary){//true if distance from target is greater than 10f
                aiDest.target = nexus;
            }
        } 
        else if(aiDest.target == nexus){
            if (Vector3.Distance(transform.position, player.position) < boundary){//true if distance from player is less than 10f
                aiDest.target = player;
            }

        }*/

        
        


    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            Entity Player = other.gameObject.GetComponent<Entity>();

            Player.combat.TakeDamage(combat.attackDamage);  //lowers players health by the amount of attack this enemy does
            //Player.health -= attackDamage;
            // TODO: update the GUI from this script

            print("OUCH: Player hurt by Grunt.\n" + "Player health = " + Player.combat.GetHealth() + "\n");
        }
        else if (other.CompareTag("Nexus")) {
            NexusEntity nexus = NexusEntity.GetInstance(); //will get you the instance of the Nexus

            // then you can do nexus.TakeDamage(___) like normal combat scripts
            nexus.combat.TakeDamage(combat.attackDamage);

            print("Nexus hurt by Grunt.\n" + "Nexus health = " + nexus.combat.GetHealth() + "\n");
        }
    }
}

