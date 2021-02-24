using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    private float tmBtwAttack;
    public float strtTimeAttack;

    //Attack position and range. Enemy Identifier. Damage
    public Transform atkPos;
    public LayerMask enemyIdentifier;
    public float atkRng;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Delay between executing an attack.
        if(tmBtwAttack <= 0) {
            if(Input.GetKey(KeyCode.Space)) {
                tmBtwAttack=strtTimeAttack;
                Collider2D[] enemyDamage = Physics2D.OverlapCircleAll(atkPos.position, atkRng, enemyIdentifier);
                for (int i = 0; i < enemyDamage.Length; i++) {
                   // enemyDamage[i].GetComponent<Enemy>().health -= damage;
                }
            }
            tmBtwAttack = strtTimeAttack;
        } else {
            tmBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(atkPos.position, atkRng);
    }
}


