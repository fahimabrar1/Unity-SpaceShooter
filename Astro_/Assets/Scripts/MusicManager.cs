using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance = null;
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
    public void getPer()
    {
        Debug.Log("audio Played on start");
        PlayerPrefs.SetInt("Soundmute", 0);
        PlayerPrefs.SetInt("Musicmute", 0);

    }

    public  void ToggleSound()
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
    public  void ToggleMusic()
    {
        Debug.Log("Entered On Toggle Music in MusicSysstem");

        if (PlayerPrefs.GetInt("Musicmute", 1) == 1)
        {
            PlayerPrefs.SetInt("Musicmute", 0);
        }
        else
        {
            PlayerPrefs.SetInt("Musicmute", 1);
        }
    }
}
