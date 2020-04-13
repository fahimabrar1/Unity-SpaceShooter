using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OptionData 
{
    public bool sound;
    public bool music;

    public OptionData(OptionManager optionManager)
    {
        sound = optionManager.sound;
        music = optionManager.music;
    }



}
