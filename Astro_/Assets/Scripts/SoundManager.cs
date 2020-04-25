using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 This Script is Responsible for Score Management in The Game UI.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/

    static OptionManager optionManager;
    public Toggle sound, music;
    public static bool soundon, musicon;


    private void Start()
    {
        optionManager = GameObject.FindObjectOfType<OptionManager>();
        if (PlayerPrefs.GetInt("Soundmute", 1)==1)
        {
            sound.isOn = true;
        }
        else
        {
            sound.isOn = false;
        }
        if (PlayerPrefs.GetInt("Musicmute", 1) == 1)
        {
            music.isOn = true;
            optionManager.Backgrounds();
        }
        else
        {
            music.isOn = false;
        }

        boolfuntions();

    }

    //boolfuntions() funtion is for Toogle Buttons.
    
    public void boolfuntions()
    {
        sound.onValueChanged.AddListener(delegate {
            optionManager.ToggleSound();
            Debug.Log("Sound bool :" + soundon);

        });

        music.onValueChanged.AddListener(delegate
        {
            optionManager.ToggleMusic();

            Debug.Log("Music bool :" + musicon);
        });
    }

    //PlaySound() function takes a parameter and playes the sound.

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Explosion":
                if (PlayerPrefs.GetInt("Soundmute",1)==1)
                {
                    optionManager.Explode();  
                }
                break;
            case "PlayerShoot":
                if (PlayerPrefs.GetInt("Soundmute", 1) == 1)
                {
                    optionManager.Shoot();
                }
                break;
        }
    }
}
