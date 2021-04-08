using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryTestScript : CavernScript
{
    // Start is called before the first frame update
    void Start()
    {
        roomSpawn(pt1, 69, 0);
        roomSpawn(pt2, 420, 0);
        roomSpawn(pt3, 1337, 0);
        roomSpawn(pt4, 8675309, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
