using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Text musictext, soundtext;
    public static bool musicon=true, soundon=true;
    public Button Musicbtn, Soundbtn;

    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Option Manager");
        musictext.text = "On";
        soundtext.text = "On";
        if (musicon)
        {
            ColorBlock mcolors = Musicbtn.colors;
            mcolors.normalColor = Color.green;
            mcolors.highlightedColor = new Color32(0, 217, 17, 255);
            Musicbtn.colors = mcolors;
        }
        else
        {
            ColorBlock mcolors = Musicbtn.colors;
            mcolors.normalColor = Color.red;
            mcolors.highlightedColor = new Color32(255, 100, 100, 255);
            Musicbtn.colors = mcolors;

        }
        if (soundon)
        {

            ColorBlock scolors = Soundbtn.colors;
            scolors.normalColor = Color.green;
            scolors.highlightedColor = new Color32(0, 217, 17, 255);
            Soundbtn.colors = scolors;
        }
        else
        {
            ColorBlock scolors = Soundbtn.colors;
            scolors.normalColor = Color.red;
            scolors.highlightedColor = new Color32(255, 100, 100, 255);
            Soundbtn.colors = scolors;

        }


    }

    public void MusicToggle()
    {
        if (musicon)
        {
            musicon = false;
            musictext.text = "Off";
            ColorBlock colors = Musicbtn.colors;
            colors.normalColor = Color.red;
            colors.highlightedColor = new Color32(255, 100, 100, 255);
            Musicbtn.colors = colors;
        }
        else
        {
            musicon = true;
            musictext.text = "On";
            ColorBlock colors = Musicbtn.colors;
            colors.normalColor = Color.green;
            colors.highlightedColor = new Color32(0, 217, 17, 255);
            Musicbtn.colors = colors;
        }
    }
    public void SoundToggle()
    {
        if (soundon)
        {
            soundon = false;
            soundtext.text = "Off";

            ColorBlock colors = Soundbtn.colors;
            colors.normalColor = Color.red;
            colors.highlightedColor = new Color32(255, 100, 100, 255);
            Soundbtn.colors = colors;
        }
        else
        {
            soundon = true;
            soundtext.text = "On";

            ColorBlock colors = Soundbtn.colors;
            colors.normalColor = Color.green;
            colors.highlightedColor = new Color32(0, 217, 17, 255);
            Soundbtn.colors = colors;
        }
    }
}
