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
        /*
        Debug.Log("Is This Running!");
        //Bullet bullet;
        SceneManager.LoadScene("chrisTesting");
        Debug.Log("Is This Running!");

        GameObject wpn = new GameObject();
        wpn.AddComponent<Weapon>();
        GameObject gunWpn = new GameObject();
        gunWpn.AddComponent<GunWeapon>();
        Weapon weapon = wpn.GetComponent<Weapon>();
        GunWeapon gunWeapon = gunWpn.GetComponent<GunWeapon>();

        for(int i = 0; i < 10; i++)
        {
            Debug.Log("Is This Running!");
            gunWeapon.Attack();
        }
        */
        
        yield return new WaitForSeconds(40);

        // Use yield to skip a frame.
        yield return null;
    }
}
