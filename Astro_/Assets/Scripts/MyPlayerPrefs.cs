using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerPrefs : MonoBehaviour
{
    private void Awake()
    {
       

        if (PlayerPrefs.GetInt("Soundmute", 1) == 1)
        {
            PlayerPrefs.SetInt("Soundmute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Soundmute", 0);
        }
        if (PlayerPrefs.GetInt("Musicmute", 1) == 1)
        {
            PlayerPrefs.SetInt("Musicmute", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Musicmute", 0);
        }
    }
}
