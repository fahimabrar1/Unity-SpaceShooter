using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    static Text score;
    static int counter,pointsval,tempcounter;
    static string points;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        counter = 0;
        score.text=counter.ToString();
        int.TryParse(PointsManager.getPoints(), out pointsval);
        points = pointsval.ToString();
        Debug.Log("Started Score System");
    }

    public static void UpdateScore()
    {
        counter+=15;
        score.text = counter.ToString();
        tempcounter += 15;
        if(tempcounter>100)
        {
           
            pointsval++;
            PointsManager.setPoints(pointsval.ToString());
            points = pointsval.ToString();
            Debug.Log(points);
            tempcounter = tempcounter - 100;
        }
        
    }

    public static string getPoints()
    {  
        return points;
    }
    public static Text getScore()
    {
        return score;
    }
}
