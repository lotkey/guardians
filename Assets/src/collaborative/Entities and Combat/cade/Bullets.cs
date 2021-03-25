using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public GameObject bullet;
    public Transform spwnPnt;
    
    public float bulletPower = 750.0f;

    void OnTriggerEnter2D(Collider2D tgt) {
        if(tgt.gameObject.tag == "pointFire") GetComponent<Rigidbody2D>().AddForce(transform.right * bulletPower);
    }
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bullet, spwnPnt.position, spwnPnt.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
