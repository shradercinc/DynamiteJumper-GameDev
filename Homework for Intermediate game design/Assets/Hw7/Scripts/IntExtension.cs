using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExtension
{
    /// <summary>
    /// checks to see if init is between two other ints [inclusive]
    /// </summary>
    /// <param name="x"></param>
    /// <param name="lower"></param>
    /// <param name="upper"></param>
    /// <returns></returns>
    public static bool IsBetween(this int x, int lower, int upper)
    {
        bool n = false;

        if (x >= lower && x <= upper)
        {
            n = true;
        }

        return n;
    }



}
