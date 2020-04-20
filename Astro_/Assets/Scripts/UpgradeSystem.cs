using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public Image Craft;
    public Sprite[] CraftSprites;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        Craft.sprite = CraftSprites[i];
        PlayerPrefs.SetInt("craft", i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextCraft()
    {

        if (i < 2)
        {
            i++;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
        else
        {
            i = 0;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
    }

    public void PrevCraft()
    {

        if (i > 0)
        {
            i--;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
        else
        {
            i = 2;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
    }
}
