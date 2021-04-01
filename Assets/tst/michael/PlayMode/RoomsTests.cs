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

        SceneManager.LoadScene("RoomTestScene");

        yield return new WaitForSeconds(10);

    }
}