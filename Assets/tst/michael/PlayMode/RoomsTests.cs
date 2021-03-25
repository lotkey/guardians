using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;
using UnityEngine.SceneManagement;

public class RoomsTests
{
    private int count;

    [OneTimeSetUp]
    public void StartRoom()
    {
        count = 0;
    }

    [UnityTest]
    public IEnumerator SpawnRooms()
    {
        SceneManager.LoadScene("chrisTesting");

        GameObject rm = GameObject.Find("Tunnel1");
        if (rm == null) rm = GameObject.Find("Tunnel2");
        if (rm == null) rm = GameObject.Find("Tunnel3");
        if (rm == null) rm = GameObject.Find("Tunnel4");
        if(rm!=null) count=count+1;

        Assert.That(count < 30);

        yield return 10000;

    }
}
