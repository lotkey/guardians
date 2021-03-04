using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEditor;

public class HUD_Tester
{
    private GameObject HUD_fab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/prefabs/garrett/HUD_Canvas.prefab");

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator HUD_TestSetClock()
    {
        // Use the Assert class to test conditions.
        var HUDinst = Object.Instantiate(HUD_fab, new Vector3(0,0,0), Quaternion.identity);

        HUDManager hudmn = HUDinst.GetComponent<HUDManager>();
        
        GameObject clock = hudmn.transform.GetChild(0).gameObject; 
        Text clock_Text = clock.GetComponent<Text>(); 

        hudmn.SetClockTime(10);
        Assert.AreEqual(clock_Text.text, "10.0");

        Debug.Log("Clock Set Test: expected = 10.0, found = " + clock_Text.text);
        yield return null;
    }

    // Verify that starting the clock results in it counting down to zero
    [UnityTest]
    public IEnumerator HUD_TestStartClock()
    {
        // Use the Assert class to test conditions.
        var HUDinst = Object.Instantiate(HUD_fab, new Vector3(0,0,0), Quaternion.identity);

        HUDManager hudmn = HUDinst.GetComponent<HUDManager>();
        
        GameObject clock = hudmn.transform.GetChild(0).gameObject; 
        Text clock_Text = clock.GetComponent<Text>(); 

        hudmn.SetClockTime(10f);
        Assert.AreEqual(hudmn.GetClockTime(), 10f); // test internal time
        Assert.AreEqual(clock_Text.text, "10.0");   // test display time
        Debug.Log("Clock Set Test: expected = 10.0, found = " + clock_Text.text);

        hudmn.StartClock();

        yield return new WaitForSeconds(10);

        Assert.AreEqual("0.0", clock_Text.text);

        Debug.Log("Clock Start Test: expected = 0.0, found = " + clock_Text.text);

        yield return null;
    }

    // Verify that starting the clock and stopping it mid-way through the countdown results keeps time accurately
    [UnityTest]
    public IEnumerator HUD_TestStopClock()
    {
        // Use the Assert class to test conditions.
        var HUDinst = Object.Instantiate(HUD_fab, new Vector3(0,0,0), Quaternion.identity);

        HUDManager hudmn = HUDinst.GetComponent<HUDManager>();
        
        GameObject clock = hudmn.transform.GetChild(0).gameObject; 
        Text clock_Text = clock.GetComponent<Text>(); 

        hudmn.SetClockTime(10f);
        hudmn.StartClock();

        yield return new WaitForSeconds(5);

        hudmn.StopClock();

        Assert.AreEqual("5.0", clock_Text.text);

        Debug.Log("Clock Set Test: expected = 5.0, found = " + clock_Text.text);

        yield return null;
    }
}
