using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPtScript : MonoBehaviour
{
    public GameObject Grunt, Brute;
    int dist;
    double rdm;
    public static double diffScaling=0;

    // Start is called before the first frame update
    void Start()
    {
        dist = (int)Mathf.Pow(Mathf.Pow(Mathf.Abs(transform.position.x), 2f) + Mathf.Pow(Mathf.Abs(transform.position.y), 2f), 0.5f);
        rdm = Random.Range(0, 9);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().isVisible){

            diffScaling = diffScaling + 0.1;
            rdm = rdm + diffScaling;

            //if(dist<10)
                if (rdm < 9)
                    Instantiate(Grunt, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else
                    Instantiate(Brute, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            //else
              //  if (rdm < 3)
                //    Instantiate(Grunt, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                //else
                  //  Instantiate(Brute, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            Debug.Log($"Enemy Spawned: {dist} from start");
            Object.Destroy(this.gameObject);
        }
    }
}
