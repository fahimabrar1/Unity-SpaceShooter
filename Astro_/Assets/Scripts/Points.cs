using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour
{
/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

In this Script is Responsible for getting points from Score System and
set the points on Points Managers for future purpose.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/

    static Text points;
    static string count;
    void Start()
    {
        points = GetComponent<Text>();
        count = PointsManager.getPoints();
        points.text = count;
    }
    public static void getPoints()
    {
        count = ScoreSystem.getPoints();
        
        points.text = count;
        PointsManager.setPoints(count);
    }
}
