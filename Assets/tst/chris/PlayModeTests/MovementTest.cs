using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    [UnityTest]
    // Stress test for the EntityMovement class
    // Primarily used by the PlayerController
    public IEnumerator MovementStressTest()
    {
        // Instatiate a GameObject and add an Entity to it
        GameObject gameObject = new GameObject();
        Entity entity = gameObject.AddComponent<Entity>();
        // Initialize some vectors to (0, 0, 0)
        // This might be redundant or unneccessary
        gameObject.transform.position = new Vector2(0, 0);
        Vector3 expectedPosition = new Vector3(0, 0, 0);
        entity.body.position = new Vector2(0, 0);
        // Set the Entity's speed to 1 for easier math
        entity.movement.speed = 1;

        // Move for 100 times
        for (int i = 0; i < 100; i++)
        {
            // The amount to move in the y direction will be -1, 0, or 1. Likewise for x
            int y = (int)Random.Range(-1, 2);
            int x = (int)Random.Range(-1, 2);
            // Instead of passing in (x, y, Time.fixedDeltaTime) I pass in (x, y, 1) for easy math
            entity.movement.Move(x, y, 1);
            // Since the "deltaTime" is 1 then the position should be updated with x * 1 and y * 1, or x and y
            expectedPosition.x += x;
            expectedPosition.y += y;
        }

        // Wait a FixedUpdate() to check
        yield return new WaitForSeconds(Time.fixedDeltaTime);

        // Vectors store doubles
        // Doubles can be prone to precision errors with arithmetic
        // I found that I would expect 1.0 and actually get 1.0001234 for example
        // To resolve this I rounded to the nearest integer
        // This is a rather crude workaround but the movement system just needs to work well, not perfectly
        // No player will be moving this much (100 moves) in this short amount of time (1/50th of a second)
        // I rounded the values and stored them in arrays for easy access
        int[] expected = { (int)Mathf.Round(expectedPosition.x), (int)Mathf.Round(expectedPosition.y) };
        int[] actual = { (int)Mathf.Round(gameObject.transform.position.x), (int)Mathf.Round(gameObject.transform.position.y) };

        // Compare the arrays
        Assert.AreEqual(expected: expected, actual: actual);
    }
}
