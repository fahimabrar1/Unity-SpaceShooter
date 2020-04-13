using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public Toggle sound, music;
    public bool soundbool, musicbool;
   
    private void Start()
    {
        Loaddata();
    }

    public void savedata()
    {
        SaveDataManager.SaveOptions(this);
    }
    public void Loaddata()
    {
        OptionData data = SaveDataManager.LoadData();
        soundbool = data.sound;
        musicbool = data.music;
        sound.isOn = soundbool;
        music.isOn = musicbool;
        Debug.Log("Sound bool in Option Manager:" + soundbool);
        Debug.Log("Music bool in Option Manager:" + musicbool);
    }
}
