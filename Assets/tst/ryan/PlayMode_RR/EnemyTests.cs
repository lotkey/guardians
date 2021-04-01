using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame=

    // Test to check if the boundary for switching targets is working for the enemies.
    [UnityTest]
    public IEnumerator EnemyBoundaryTest()
    {
        //these are useless
        //GameObject gameObject = new GameObject();
        //Enemy grunt = gameObject.AddComponent<Enemy>();

        //this is supposed to instantiate a grunt prefab.
        //GameObject.Instantiate(Resources.Load("Assets/prefabs/ryan/Grunt") as GameObject);
        

        yield return null;
    }

    // Test to check that enemies can actually lower the health value of their target when attacking
    [UnityTest]
    public IEnumerator EnemyDealDamageTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    // Test to see if there is a limit to how many enemies can deal damage at the exact same time.
    [UnityTest]
    public IEnumerator EnemyStressTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
