using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour
{
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
