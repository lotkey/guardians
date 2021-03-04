using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ExampleScript
{
	// the hypotenuse length for two vectors
    public static double fun1(int vel_X, int vel_Y)
    {
    	double inner = Math.Pow(vel_X, 2) + Math.Pow(vel_Y, 2);
    	return Math.Sqrt(inner);
    }

    // flips a boolean value
    public static bool inverter(bool verse)
    {
    	bool inverse = !verse;
    	return inverse;
    }

}
