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
        gameObject.transform.position = new Vector2(0, 0);
        Vector3 expectedPosition = new Vector3(0, 0, 0);
        entity.movement.speed = 1;
        entity.body.position = new Vector2(0, 0);

        for (int i = 0; i < 100; i++)
        {
            int y = (int)Random.Range(-1, 2);
            int x = (int)Random.Range(-1, 2);
            entity.movement.Move(x, y, 1);
            expectedPosition.x += x;
            expectedPosition.y += y;
        }


        yield return new WaitForSeconds(Time.fixedDeltaTime);

        int[] expected = { (int)Mathf.Round(expectedPosition.x), (int)Mathf.Round(expectedPosition.y) };
        int[] actual = { (int)Mathf.Round(gameObject.transform.position.x), (int)Mathf.Round(gameObject.transform.position.y) };

        Assert.AreEqual(expected: expected, actual: actual);

    }
}
