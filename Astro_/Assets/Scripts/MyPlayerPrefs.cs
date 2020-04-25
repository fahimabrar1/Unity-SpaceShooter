using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerPrefs : MonoBehaviour
{
    /*---------------------------------------------------------------------------------
     ----------------------------------------------------------------------------------
     
     In this Script Default Sound,Music and Player Stats are set.
     It will be saved When the Game is first Launch After installation.

     ----------------------------------------------------------------------------------
     ---------------------------------------------------------------------------------*/
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
        //Setup Upgrade Systems (Helps to Reset powers)
        if (PlayerPrefs.GetInt("start") == 1)
        {
            PlayerPrefs.SetInt("start", 1);
        }
        else
        {
            PlayerPrefs.SetInt("start", 0);
        }
        SetCraftDetails();
    }

    /*---------------------------
     -----------Temp Changes-----
     ----------------------------*/
    void SetCraftDetails()
    {

        if (PlayerPrefs.GetInt("start", 0) == 0)
        {
            PlayerPrefs.SetInt("start", 1);

            PlayerPrefs.SetInt("Heli_LB", 1);
            PlayerPrefs.SetInt("Heli_BA", 25);
            PlayerPrefs.SetInt("Heli_MM", 0);

            PlayerPrefs.SetInt("SpaceShip_LB", 1);
            PlayerPrefs.SetInt("SpaceShip_BA", 25);
            PlayerPrefs.SetInt("SpaceShip_MM", 0);

            PlayerPrefs.SetInt("Corvette_LB", 1);
            PlayerPrefs.SetInt("Corvette_BA", 25);
            PlayerPrefs.SetInt("Corvette_MM", 0);
        }
    }
    /*---------------------------
      -----------Temp Changes-----
      ----------------------------*/
}
