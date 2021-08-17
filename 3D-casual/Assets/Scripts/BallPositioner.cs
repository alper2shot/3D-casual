using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallPositioner : MonoBehaviour
{
    public static bool isIn=false;

    public static void MakeTrue()
    {
        isIn = true;
    }

    public static void MakeFalse()
    {
        isIn = false;
    }
}
