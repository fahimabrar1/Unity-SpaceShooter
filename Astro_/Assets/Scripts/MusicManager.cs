using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    static MusicManager instance = null;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            PlayerPrefs.SetInt("Soundmute", 1);
            PlayerPrefs.SetInt("Musicmute", 1);
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
       
    }

    public  void ToggleSound()
    {
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
