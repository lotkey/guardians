using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour
{
    public GameObject Collapse1, Collapse2, Collapse3, Fish, Gem, SmallRm, Tunnel1, Tunnel2, Tunnel3, Tunnel4,
        Multi, Arena, Split1, Split2, Split3, Cathedral, Switchback, Stlth, Tri, Spade;
    float angleX, angleY;
    int side;

    // Start is called before the first frame update
    void Start()
    {
        int seed = Random.Range(0, 16);

        Spawn(seed);
    }

    public void Spawn(int seed) 
    { 
        if(transform.rotation.eulerAngles.z == 90f)
        {
            angleX = -0.5f;
            angleY = 9.5f;
            side = 3;
        }
        else if(transform.rotation.eulerAngles.z == 270f)
        {
            angleX = 0.5f;
            angleY = -9.5f;
            side = 2;
        }
        else
        {
            angleX = 9.5f;
            angleY = 0.5f;
            side = 0;
        }


        switch (seed+side)
        {
            case 0:
                Instantiate(Collapse1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 1:
                Instantiate(Collapse2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 2:
                Instantiate(Collapse3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 3:
                Instantiate(Fish, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 4:
                Instantiate(Gem, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 5:
                Instantiate(SmallRm, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 6:
                Instantiate(Tunnel1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 7:
                Instantiate(Tunnel2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 8:
                Instantiate(Tunnel3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 9:
                Instantiate(Tunnel4, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 10:
                Instantiate(Multi, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 11:
                Instantiate(Arena, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 12:
                Instantiate(Split1, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 13:
                Instantiate(Split2, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 14:
                Instantiate(Split3, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 15:
                Instantiate(Cathedral, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 16:
                Instantiate(Switchback, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 17:
                Instantiate(Spade, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 18:
                Instantiate(Tri, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
                break;
            case 19:
                Instantiate(Stlth, new Vector3(transform.position.x + angleX, transform.position.y + angleY, 0), Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
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
