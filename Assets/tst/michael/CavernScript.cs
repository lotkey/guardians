using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavernScript : MonoBehaviour
{
    public GameObject room, pt1, pt2, pt3, pt4;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(room, new Vector3(pt1.transform.position.x - 0.5f, pt1.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
        Instantiate(room, new Vector3(pt2.transform.position.x + 9.5f, pt2.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(room, new Vector3(pt3.transform.position.x + 9.5f, pt3.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(room, new Vector3(pt4.transform.position.x + 0.5f, pt4.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
