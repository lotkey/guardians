using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class EnemyTests
{

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator EnemyBoundaryTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        
        yield return null;
    }

    [UnityTest]
    public IEnumerator EnemyDealDamageTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }

    [UnityTest]
    public IEnumerator EnemyStressTest()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
