using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public Image Craft;
    public Sprite[] CraftSprites;
    public Text point,CraftLB,CraftBA,CraftMM;
    int max_LB, max_BA, max_Missiles;
    int value;
    int i = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        max_LB = 4;
        max_BA = 35;
        max_Missiles = 4;
        i = 0;
        Craft.sprite = CraftSprites[i];
        PlayerPrefs.SetInt("craft", i);
        point.text = PointsManager.getPoints();
        int.TryParse(point.text,out value);
        Debug.Log(value);
        if(PlayerPrefs.GetInt("start")==1)
        {
            PlayerPrefs.SetInt("start",1);
        }
        else
        {
            PlayerPrefs.SetInt("start", 0);
        }
        SetCraftDetails();

        GetCraftDetails(i);
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

    void GetCraftDetails(int index)
    {
        Craft.sprite = CraftSprites[i];
        PlayerPrefs.SetInt("craft", i);
        switch (index)
        {
            case 0:
                CraftLB.text = PlayerPrefs.GetInt("Heli_LB").ToString();
                CraftBA.text = PlayerPrefs.GetInt("Heli_BA").ToString();
                CraftMM.text = PlayerPrefs.GetInt("Heli_MM").ToString();
                break;
            case 1:
                CraftLB.text = PlayerPrefs.GetInt("SpaceShip_LB").ToString();
                CraftBA.text = PlayerPrefs.GetInt("SpaceShip_BA").ToString();
                CraftMM.text = PlayerPrefs.GetInt("SpaceShip_MM").ToString();
                break;
            case 2:
                CraftLB.text = PlayerPrefs.GetInt("Corvette_LB").ToString();
                CraftBA.text = PlayerPrefs.GetInt("Corvette_BA").ToString();
                CraftMM.text = PlayerPrefs.GetInt("Corvette_MM").ToString();
                break;

        }
    }

    public void LightingBolts() 
    {
        switch (PlayerPrefs.GetInt("craft")) {
            case 0:
                PowerUp("Heli_LB");
                break;
            case 1:
                PowerUp("SpaceShip_LB");
                break;
            case 2:
                PowerUp("Corvette_LB");
                break;
        }
        
    }

    void PowerUp(string name)
    {
        //set to 15000
        int powerup = PlayerPrefs.GetInt(name);
        if (value > 0 && powerup < 5)
        {
            value -= 1;
            point.text = value.ToString();
            PointsManager.setPoints(point.text);
            powerup++;
            PlayerPrefs.SetInt(name, powerup);
            GetCraftDetails(PlayerPrefs.GetInt("craft"));

        }
    }

    public void BoltAcceleratior() 
    {
        switch (PlayerPrefs.GetInt("craft"))
        {
            case 0:
                BoltUp("Heli_BA");
                break;
            case 1:
                BoltUp("SpaceShip_BA");
                break;
            case 2:
                BoltUp("Corvette_BA");
                break;
        }
    }
    
    void BoltUp(string name)
    {
        int boltup = PlayerPrefs.GetInt(name);
        if (value > 1 && boltup < 36)
        {
            value -= 2;
            point.text = value.ToString();
            PointsManager.setPoints(point.text);
            boltup++;
            PlayerPrefs.SetInt(name, boltup);
            GetCraftDetails(PlayerPrefs.GetInt("craft"));

        }
    }

    public void Missiles()
    {
        switch (PlayerPrefs.GetInt("craft"))
        {
            case 0:
                MissileUp("Heli_MM");
                break;
            case 1:
                MissileUp("SpaceShip_MM");
                break;
            case 2:
                MissileUp("Corvette_MM");
                break;
        }
    }

    void MissileUp(string name)
    {
        int missileup = PlayerPrefs.GetInt(name);
        if (value > 50000 && missileup < 3)
        {
            value -= 50000;
            point.text = value.ToString();
            PointsManager.setPoints(point.text);
            missileup++;
            PlayerPrefs.SetInt(name, missileup);
            GetCraftDetails(PlayerPrefs.GetInt("craft"));

        }
    }

    public void NextCraft()
    {

        if (i < 2)
        {
            i++;
            GetCraftDetails(i);
        }
        else
        {
            i = 0;
            GetCraftDetails(i);
        }
    }

    public void PrevCraft()
    {

        if (i > 0)
        {
            i--;
            GetCraftDetails(i);
        }
        else
        {
            i = 2;
            GetCraftDetails(i);
        }
    }
}
