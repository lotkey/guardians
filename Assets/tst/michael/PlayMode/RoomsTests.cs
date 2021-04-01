using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class RoomsTests
{

    [OneTimeSetUp]
    public void StartRoom()
    {

    }

    [UnityTest]
    public IEnumerator SpawningFunctionalityCheck()
    {
        GameObject T1Fab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/src/michael/Tunnel1.prefab");
        GameObject T1Ins = Object.Instantiate(T1Fab, new Vector3(0, 0, 0), Quaternion.identity);

        GameObject T1Pt = GameObject.Find("Pt");
        RoomScript T1Sc = T1Pt.GetComponent<RoomScript>();

        T1Sc.Spawn(1);

        yield return new WaitForSeconds(3);

        T1Pt = GameObject.Find("Pt");

        Assert.IsNull(T1Pt);
    }

    [UnityTest]
    public IEnumerator SpawnRooms()
    {
        int count = 0;

        SceneManager.LoadScene("chrisTesting");

        yield return new WaitForSeconds(10);

        GameObject rm = GameObject.Find("Tunnel1(Clone)");
        if (rm != null) count = count + 1;
        rm = GameObject.Find("Tunnel2(Clone)");
        if (rm != null) count = count + 1;
        rm = GameObject.Find("Tunnel3(Clone)");
        if (rm != null) count = count + 1;
        rm = GameObject.Find("Tunnel4(Clone)");
        if (rm != null) count = count + 1;

        Assert.AreEqual(count,0);
    }
}
