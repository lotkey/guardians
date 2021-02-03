using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChild : Enemy
{
    // Start is called before the first frame update
    void Start() {
        base.Start();  // calls the Start() method in the parent class
        // other start stuff here...
    }

    // Update is called once per frame
    void Update() {
        //rigidBody2D.AddForce(speed);
        // Do enemy things
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            //playerHealth.DamagePlayer(damage);  //might have to make a playerHealth class for this to work
        }
    }
}
