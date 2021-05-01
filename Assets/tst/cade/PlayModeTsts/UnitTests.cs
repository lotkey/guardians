using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class test
{

    //Unity test for Gun attack
    [UnityTest]
    public IEnumerator unitTestGunAttack()
    {
        /*
        GameObject wpn = new GameObject();
        //wpn.AddComponent<Weapon>();
        GameObject gunWpn = new GameObject();
        gunWpn.AddComponent<GunWeapon>();
        Weapon weapon = wpn.GetComponent<Weapon>();
        Weapon gunWeapon = gunWpn.GetComponent<GunWeapon>();
        weapon.cooldownTimeAmount = 1f;
        weapon.cooldownTimeEnd = 0f;

        Assert.IsTrue(gunWeapon.Attack());
        */
        // Use yield to skip a frame.
        yield return null;
    }

    //Unit test for Melee attack function
    [UnityTest]
    public IEnumerator unitTestMeleeAttack()
    {
        /*
        GameObject wpn = new GameObject();
        wpn.AddComponent<Weapon>();
        GameObject meleeWpn = new GameObject();
        meleeWpn.AddComponent<MeleeWeapon>();
        Weapon weapon = wpn.GetComponent<Weapon>();
        Weapon meleeWeapon = meleeWpn.GetComponent<MeleeWeapon>();

        Assert.IsTrue(meleeWeapon.Attack());
        */
        // Use yield to skip a frame.
        yield return null;
    }
}
