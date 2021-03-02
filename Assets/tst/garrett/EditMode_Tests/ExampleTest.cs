using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;

public class ExampleTest
{

    // Tests that the distance caluculated is accurate
    [Test]
    public void DistanceTest()
    {
        // test case 1
        double dist1 = ExampleScript.fun1(1, 1);
        double dist1_ans = Math.Sqrt(2);

        // test case 2
        double dist0 = ExampleScript.fun1(0, 0);
        double dist0_ans = Math.Sqrt(0);

        Assert.AreEqual(dist1, dist1_ans);
        Assert.AreEqual(dist0, dist0_ans);

        Debug.Log("dist1 == " + dist1_ans + " : " + (dist1 == dist1_ans));
        //LogAssert.Expect(LogType.Log, "dist1 == " + dist1_ans + " : True");
    }

    // Test that the value returned is flipped
    [Test]
    public void TestInverter()
    {
        bool test_val = true;

        test_val = ExampleScript.inverter(test_val);

        Assert.IsFalse(test_val);

        test_val = ExampleScript.inverter(test_val);

        Assert.IsTrue(test_val);
    }

    // One way to automate tests
    [Test]
    public void RunAll()
    {
        DistanceTest();
        TestInverter();
    }
}
