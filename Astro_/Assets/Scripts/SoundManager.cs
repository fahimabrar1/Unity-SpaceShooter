using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioClip background,explosion,shoot;
    static AudioSource audio;
    public Toggle sound, music;
    public static bool soundon, musicon;

    OptionManager optionManager;

    private void Awake()
    {

        explosion = Resources.Load<AudioClip>("Explosion");
        shoot = Resources.Load<AudioClip>("PlayerShoot");
        background = Resources.Load<AudioClip>("bensound-scifi");
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(background);
        
    }

    private void Start()
    {
        //Loaddata();
        boolfuntions();
    }
    public void boolfuntions()
    {
        sound.onValueChanged.AddListener(delegate {
            soundon = sound.isOn;
        });

        music.onValueChanged.AddListener(delegate
        {
            musicon = music.isOn;
            Debug.Log("Music bool :" + musicon);
        });
    }
  
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Explosion":
                if (soundon)
                {
                    audio.PlayOneShot(explosion);
                }
                break;
            case "PlayerShoot":
                if (soundon)
                {
                    audio.PlayOneShot(shoot);
                }
                break;
        }
    }
    public  void SoundSystem()
    {
        if (soundon)
        {
            soundon = false;
        }
        else
        {
           soundon = true;
        }
    }
    public void MusicSystem()
    {
        if (musicon)
        {
            musicon = false;
            audio.Stop();
        }
        else
        {
            musicon = true;
            audio.PlayOneShot(background);
        }
    }

    /*public void Loaddata()
    {
        OptionData data = SaveDataManager.LoadData();
        soundon = data.sound;
        musicon = data.music;
        sound.isOn = soundon;
        music.isOn = musicon;
        Debug.Log("Sound bool in Sound Manager:" + soundon);
        Debug.Log("Music bool in Sound Manager:" + musicon);

    }*/
}
