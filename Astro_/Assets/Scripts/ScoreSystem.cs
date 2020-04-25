using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

 /*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 This Script is Responsible for Score Management in The Game UI.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/

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

    //UpdateScore() function updates the score whenever an asteroid is Destroyed.

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

    //getPoints() function returns Points.

    public static string getPoints()
    {  
        return points;
    }

    //getScore() function returns Score.

    public static Text getScore()
    {
        return score;
    }

    //getScoreCount() function returns Count.

    public static int getScoreCount()
    {
        return counter;
    }
}
