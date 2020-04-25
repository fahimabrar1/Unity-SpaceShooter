using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

In this Script is Responsible for managing points  into Scenes.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/

    static PointsManager instance = null;
    static string point;
    private void Awake()
    {
        if (instance != null && instance != this.gameObject)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed");
        }
        else
        {
            instance = this;
            Debug.Log("instanced");
        }
        DontDestroyOnLoad(this.gameObject);
    }

      private void Start()
      {
        Debug.Log("Pool manager Started");
        point = PlayerPrefs.GetString("PP");
      }

    //setPoints() stores the points throughout the game sceenes.

    public static void setPoints(string p)
    {
        point = p;
        PlayerPrefs.SetString("PP", point);
    }

    //setPoints() return points throughout the game sceenes.

    public static string getPoints()
    {
        return point;
    }

 

}
