using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class test
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator unitTestAttack()
    {
        
        GameObject wpn = new GameObject();
        wpn.AddComponent<Weapon>();
        GameObject gunWpn = new GameObject();
        gunWpn.AddComponent<GunWeapon>();
        Weapon weapon = wpn.GetComponent<Weapon>();
        Weapon gunWeapon = gunWpn.GetComponent<GunWeapon>();
        weapon.cooldownTimeAmount = 1f;
        weapon.cooldownTimeEnd = 0f;

        Assert.IsTrue(gunWeapon.Attack());
        // Use yield to skip a frame.
        yield return null;
    }
}
