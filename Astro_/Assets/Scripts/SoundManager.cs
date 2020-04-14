using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private MusicManager musicManager;
    public static AudioClip background,explosion,shoot;
    static AudioSource audio;
    public Toggle sound, music;
    public static bool soundon, musicon;


    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Explosion");
        shoot = Resources.Load<AudioClip>("PlayerShoot");
        background = Resources.Load<AudioClip>("bensound-scifi");
        audio =  GetComponent<AudioSource>();
    }

    private void Start()
    {
        /*musicManager.getPer();*/
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
            Debug.Log("audio Played on start");
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
            Debug.Log("Sound bool :" + soundon);

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
            Debug.Log("audio Played on MusicSystem");
            audio.PlayOneShot(background);
        }
    }
}
