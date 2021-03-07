using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : Enemy
{
    public Transform target;//set target from inspector or start()
                            //also can change target while running using update

    // This function is used for reseting the default values from the superclass
    public void Reset() {
        /*
         * Yo Ryan I changed some code to fix the compiler errors so I could work on the project
         */
        combat.attackDamage = 4f;    // default amount
        combat.SetMaxHealth(150f);   // default amount
        movement.speed = 1f;     // default amount
    }
    // Start is called before the first frame update
    new void Start() {
        base.Start();  // calls the Start() method in the parent class
        target = FindObjectOfType<Player>().transform; //GameObject.Find("Player").transform;  // sets target of grunt to Player
    }

    // Update is called once per frame
    void Update() {
        //--==-- Begin Movement --==--
        
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation

        //move towards the player
        if (Vector3.Distance(transform.position,target.position)>0.6f){//move if distance from target is greater than 0.6
            transform.Translate(new Vector3(movement.speed* Time.deltaTime,0,0) );
        }
        //--==-- End Movement --==--


    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){

            Entity Player = other.gameObject.GetComponent<Entity>();

            Player.combat.TakeDamage(combat.attackDamage);  //lowers players health by the amount of attack this enemy does
            //Player.health -= attackDamage;

            print("OUCH: Player hurt by Brute.\n" + "Player health = " + Player.combat.GetHealth() + "\n");
        
            
        }
    }
}
