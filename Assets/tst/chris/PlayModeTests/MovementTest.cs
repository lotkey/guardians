using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    [UnityTest]
    public IEnumerator MovementStressTest()
    {
        GameObject gameObject = new GameObject();
        Entity entity = gameObject.AddComponent<Entity>();
        entity.movement = gameObject.AddComponent<EntityMovement>();
        gameObject.transform.position = new Vector3(0, 0, 0);
        Vector3 expectedPosition = new Vector3(0, 0, 0);
        entity.movement.speed = 1;

        for (int i = 0; i < 1000; i++)
        {
            float y = (int)Random.Range(-1, 2);
            float x = (int)Random.Range(-1, 2);
            entity.movement.Move(x, y, 1);
            expectedPosition.x += x;
            expectedPosition.y += y;
        }


        yield return new WaitForSeconds(Time.fixedDeltaTime);

        Assert.AreEqual(expected: expectedPosition, actual: gameObject.transform.position);

    }
}
