using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    static OptionManager instance = null;
    AudioSource audio;
    AudioClip background, shoot, explode;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
    private void Start()
    {
        Debug.Log("Called OptionManager");

        background = Resources.Load<AudioClip>("bensound-scifi");
        shoot = Resources.Load<AudioClip>("PlayerShoot");
        explode = Resources.Load<AudioClip>("Explosion");
        audio = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        audio.PlayOneShot(shoot);
    }
    public void Backgrounds()
    {
        audio.PlayOneShot(background);
    }
    public void Explode()
    {
        audio.PlayOneShot(explode);
    }
    public void StopAudio()
    {
        audio.Stop();
    }

    public void ToggleSound()
    {
        Debug.Log("Entered On Toggle Sound in MusicSysstem");

        if (PlayerPrefs.GetInt("Soundmute", 1) == 1)
        {
            PlayerPrefs.SetInt("Soundmute", 0);

        }
        else
        {
            PlayerPrefs.SetInt("Soundmute", 1);
        }
    }
    public void ToggleMusic()
    {
        Debug.Log("Entered On Toggle Music in MusicSysstem");

        if (PlayerPrefs.GetInt("Musicmute", 1) == 1)
        {
            PlayerPrefs.SetInt("Musicmute", 0);
            StopAudio();
        }
        else
        {
            PlayerPrefs.SetInt("Musicmute", 1);
            Backgrounds();
        }
    }
}
