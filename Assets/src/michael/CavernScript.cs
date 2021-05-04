using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CavernScript : MonoBehaviour
{
    public GameObject
        //Collapse1, Collapse2, Collapse3, Fish, Gem, SmallRm, 
        Tunnel1, Tunnel2, Tunnel3, Tunnel4, Multi, pt1, pt2, pt3, pt4;

    // Start is called before the first frame update
    void Start()
    {
        int seed = Random.Range(0, 9999);

        roomSpawn(pt1, (seed % 10), 0);
        roomSpawn(pt2, (seed % 100) / 10, 1);
        roomSpawn(pt3, (seed % 1000) / 100, 2);
        roomSpawn(pt4, (seed) / 1000, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void roomSpawn(GameObject point, int seed, int end)
    {
        if (end == 0)
            switch (seed)
            {
                case 1:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 2:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 3:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 4:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 5:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 6:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 7:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 8:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 9:
                    Instantiate(Multi, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 0:
                    Instantiate(Multi, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                default:
                    Debug.Log($"Invalid Room Number Tried to Spawn: {seed}");
                    break;
            }
        else if (end == 1)
            switch (seed)
            {
                case 1:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 2:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 3:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 4:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 5:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 6:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 7:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 8:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 9:
                    Instantiate(Multi, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 0:
                    Instantiate(Multi, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                default:
                    Debug.Log($"Invalid Room Number Tried to Spawn: {seed}");
                    break;
            }
        else if (end == 2)
            switch (seed)
            {
                case 1:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 2:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 3:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 4:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 5:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 6:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 7:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 8:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 9:
                    Instantiate(Multi, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 0:
                    Instantiate(Multi, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                default:
                    Debug.Log($"Invalid Room Number Tried to Spawn: {seed}");
                    break;
            }
        else if (end == 3)
            switch (seed)
            {
                case 1:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 2:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 3:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 4:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 5:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 6:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 7:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 8:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 9:
                    Instantiate(Multi, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 0:
                    Instantiate(Multi, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                default:
                    Debug.Log($"Invalid Room Number Tried to Spawn: {seed}");
                    break;
            }
    }
}
