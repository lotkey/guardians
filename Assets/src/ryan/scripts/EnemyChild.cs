using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChild : Enemy
{
    // This function is used for reseting the default values from the superclass
    public void Reset() {
        combat.attackDamage = 10f;    // default amount
        combat.SetMaxHealth(100f);   // default amount
        movement.speed = 10f;     // default amount
    }
    // Start is called before the first frame update
    new void Start() {
        base.Start();  // calls the Start() method in the parent class
        // other start stuff here...
    }

    
    // Update is called once per frame
    new void Update() {
        base.Update();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            //playerHealth.DamagePlayer(damage);  //might have to make a playerHealth class for this to work
        }
    }
}
