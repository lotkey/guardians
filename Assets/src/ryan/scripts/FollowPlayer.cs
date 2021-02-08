using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//RDR

// Script for an entity to follow the player.
public class FollowPlayer : MonoBehaviour {
 
    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 2f;
 
    //private GameObject Player;
 
    void Start () {
        //Player = GameObject.Find("Player");
        target = GameObject.Find("Player").transform;
    }
     
     /* // This update function is simpler and doesn't involve rotating or setting target in inspector panel
    void Update () {
        transform.position = Vector2.MoveTowards(transform.position,Player.transform.position, speed*Time.deltaTime);
    }*/

    //This update function involves rotation
    void Update(){
         
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
         
         
        //move towards the player
        if (Vector3.Distance(transform.position,target.position)>0.6f){//move if distance from target is greater than 1
            transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
        }
 
    }
 
 }
