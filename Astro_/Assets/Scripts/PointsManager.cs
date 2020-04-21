using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
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
  
    public static void setPoints(string p)
    {
        point = p;
        PlayerPrefs.SetString("PP", "0");
    }
    public static string getPoints()
    {
        return point;
    }

 

}
