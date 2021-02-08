using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brute : Enemy
{
    public Transform target;//set target from inspector or start()
                            //also can change target while running using update

    // This function is used for reseting the default values from the superclass
    public void Reset() {
        attackDamage = 4f;    // default amount
        health = 150f;   // default amount
        speed = 1f;     // default amount
    }
    // Start is called before the first frame update
    new void Start() {
        base.Start();  // calls the Start() method in the parent class
        target = GameObject.Find("Player").transform;  // sets target of grunt to Player
    }

    // Update is called once per frame
    void Update() {
        //--==-- Begin Movement --==--
        
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation

        //move towards the player
        if (Vector3.Distance(transform.position,target.position)>0.6f){//move if distance from target is greater than 0.6
            transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
        }
        //--==-- End Movement --==--


    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            //playerHealth.DamagePlayer(damage);  //might have to make a playerHealth class for this to work
            print("OUCH: Player hurt by Brute.\n");
        }
    }
}
