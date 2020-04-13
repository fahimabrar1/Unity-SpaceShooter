using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
     MusicManager musicManager;
    public static AudioClip background,explosion,shoot;
    static AudioSource audio;
    public Toggle sound, music;
    public static bool soundon, musicon;


    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Explosion");
        shoot = Resources.Load<AudioClip>("PlayerShoot");
        background = Resources.Load<AudioClip>("bensound-scifi");
        audio = GetComponent<AudioSource>();        
    }

    private void Start()
    {
        musicManager = FindObjectOfType<MusicManager>();
        boolfuntions();
        if (PlayerPrefs.GetInt("Soundmute", 1) == 1)
        {
            soundon = true;
            sound.isOn = soundon;
        }
        else
        {
            soundon = false;
            sound.isOn = soundon;

        }
        if (PlayerPrefs.GetInt("Musicmute", 1) == 1)
        {
            musicon = true;
            music.isOn = musicon;
            audio.PlayOneShot(background);
        }
        else
        {
            musicon = false;
            music.isOn = musicon;

        }
    }
    public void boolfuntions()
    {
        sound.onValueChanged.AddListener(delegate {
            if (PlayerPrefs.GetInt("Soundmute", 1) == 1)
            {
                musicManager.ToggleSound();
                soundon = true;
                sound.isOn = soundon;
            }
            else
            {
                musicManager.ToggleSound();
                soundon = false;
                sound.isOn = soundon;

            }
        });

        music.onValueChanged.AddListener(delegate
        {
            if (PlayerPrefs.GetInt("Musicmute", 1) == 1)
            {
                musicManager.ToggleMusic();
                musicon = true;
                music.isOn = musicon;

            }
            else
            {
                musicManager.ToggleMusic();
                musicon = false;
                music.isOn = musicon;

            }
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
