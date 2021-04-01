using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class StressTests
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator BulletsAblazeStress()
    {
        SceneManager.LoadScene("chrisTesting");
        Sprite mySprite;
        Texture2D tex = new Texture2D(128,128);
        float damage = 3.0f;
        float speed = 2.0f;
        Vector2 direction = new Vector2(0.0f,0.0f);

        for(int i = 0; i < 10; i++)
        {
            GameObject gameObject = new GameObject();
            SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>() as SpriteRenderer;
            sr.color = new Color(0.9f,0.9f,0.9f,1.0f);
            mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), direction);
            Bullets bullet = new Bullets(direction,speed,damage);
        }
        
        yield return new WaitForSeconds(40);

        // Use yield to skip a frame.
        yield return null;
    }
}
