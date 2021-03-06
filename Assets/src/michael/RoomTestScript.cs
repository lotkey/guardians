using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTestScript : MonoBehaviour
{
    public static int roomCount = 0;
    public GameObject Collapse1, Collapse2, Collapse3, Fish, Gem, SmallRm, Tunnel1, Tunnel2, Tunnel3, Tunnel4;
    float angleX, angleY;

    // Start is called before the first frame update
    void Start()
    {
        int seed = Random.Range(0, 9);

        //if (this.transform.position.y < 100 && this.transform.position.y > -100 && this.transform.position.x < 100 && this.transform.position.x > -100)
        Spawn(6);
        roomCount++;
        Debug.Log($"Room {roomCount + 1} spawned");
        //else Spawn(5);
    }

    public void Spawn(int seed)
    {
        if (transform.rotation.eulerAngles.z == 90f)
        {
            angleX = -0.5f;
            angleY = 9.5f;
        }
        else if (transform.rotation.eulerAngles.z == 270f)
        {
            angleX = 0.5f;
            angleY = -9.5f;
        }
        else
        {
            angleX = 9.5f;
            angleY = 0.5f;
        }

        switch (seed)
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
