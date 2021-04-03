using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CavernScript : MonoBehaviour
{
    public GameObject Collapse1, Collapse2, Collapse3, Fish, Gem, SmallRm, Tunnel1, Tunnel2, Tunnel3, Tunnel4, pt1, pt2, pt3, pt4;

    // Start is called before the first frame update
    void Start()
    {
        int seed = Random.Range(0, 9999);

        /*
        Collapse1 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Collapse1.prefab");
        Collapse2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Collapse2.prefab");
        Collapse3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Collapse3.prefab");
        Fish = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Fish.prefab");
        Gem = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Gem.prefab");
        SmallRm = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/SmallRm.prefab");
        Tunnel1 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Tunnel1.prefab");
        Tunnel2 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Tunnel2.prefab");
        Tunnel3 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Tunnel3.prefab");
        Tunnel4 = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Tunnel4.prefab");
        */
        roomSpawn(pt1, (seed % 10), 0);
        roomSpawn(pt2, (seed % 100) / 10, 1);
        roomSpawn(pt3, (seed % 1000) / 100, 2);
        roomSpawn(pt4, (seed) / 1000, 3);

        //Instantiate(Collapse1, new Vector3(pt1.transform.position.x - 0.5f, pt1.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
        //Instantiate(Collapse2, new Vector3(pt2.transform.position.x + 9.5f, pt2.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        //Instantiate(Collapse1, new Vector3(pt3.transform.position.x + 9.5f, pt3.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
        //Instantiate(Collapse2, new Vector3(pt4.transform.position.x + 0.5f, pt4.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
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
                case 0:
                    Instantiate(Collapse1, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 1:
                    Instantiate(Collapse2, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 2:
                    Instantiate(Collapse3, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 3:
                    Instantiate(Fish, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 4:
                    Instantiate(Gem, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 5:
                    Instantiate(SmallRm, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 6:
                    Object.Instantiate(Tunnel1, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 7:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 8:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                case 9:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x - 0.5f, point.transform.position.y + 9.5f, 0), Quaternion.Euler(0f, 0f, 90f));
                    break;
                default:
                    break;
            }
        else if (end == 1)
            switch (seed)
            {
                case 0:
                    Instantiate(Collapse1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 1:
                    Instantiate(Collapse2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 2:
                    Instantiate(Collapse3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 3:
                    Instantiate(Fish, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 4:
                    Instantiate(Gem, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 5:
                    Instantiate(SmallRm, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 6:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 7:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 8:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 9:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                default:
                    break;
            }
        else if (end == 2)
            switch (seed)
            {
                case 0:
                    Instantiate(Collapse1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 1:
                    Instantiate(Collapse2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 2:
                    Instantiate(Collapse3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 3:
                    Instantiate(Fish, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 4:
                    Instantiate(Gem, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 5:
                    Instantiate(SmallRm, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 6:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 7:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 8:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                case 9:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 9.5f, point.transform.position.y + 0.5f, 0), Quaternion.Euler(0f, 0f, 0f));
                    break;
                default:
                    break;
            }
        else if (end == 3)
            switch (seed)
            {
                case 0:
                    Instantiate(Collapse1, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 1:
                    Instantiate(Collapse2, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 2:
                    Instantiate(Collapse3, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 3:
                    Instantiate(Fish, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 4:
                    Instantiate(Gem, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 5:
                    Instantiate(SmallRm, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 6:
                    Instantiate(Tunnel1, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 7:
                    Instantiate(Tunnel2, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 8:
                    Instantiate(Tunnel3, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                case 9:
                    Instantiate(Tunnel4, new Vector3(point.transform.position.x + 0.5f, point.transform.position.y - 9.5f, 0), Quaternion.Euler(0f, 0f, 270f));
                    break;
                default:
                    break;
            }
    }
}
