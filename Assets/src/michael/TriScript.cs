using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is specialized for the room points coming off the sides of certain large rooms, such as Tri, where we name it.
 * The spawn function is overidden, as less rooms are allowed, or we would overlap other rooms
 */ 
public class TriScript : RoomScript
{
    //These are the only rooms appropriate for splitting off the sides of these rooms
    public GameObject Collapse1, Collapse2, Collapse3, Fish, Gem, SmallRm;
    float angleX, angleY, angleZ;
    int side;

    /*// Start is called before the first frame update
    void Start()
    {
        int seed = Random.Range(0, 16);

        Spawn(seed);
    }*/

    public override void Spawn(int seed)
    {
        if (transform.rotation.eulerAngles.z == 90f)
        {
            angleX = 9.5f;
            angleY = 0.5f;
            angleZ = -90f;
        }
        else
        {
            angleX = -9.5f;
            angleY = -0.5f;
            angleZ = 0f;
        }

        switch (seed%5)
        {
            case 0:
                Instantiate(Collapse1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+angleZ));
                break;
            case 1:
                Instantiate(Collapse2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+angleZ));
                break;
            case 2:
                Instantiate(Collapse3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+angleZ));
                break;
            case 3:
                Instantiate(Fish, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+angleZ));
                break;
            case 4:
                Instantiate(Gem, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+angleZ));
                break;
            case 5:
                Instantiate(SmallRm, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z+angleZ));
                break;
            default:
                break;
        }

        Object.Destroy(this.gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
