using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public  AudioSource audio;
    AudioClip background;
    public GameObject panel,pausebutton;
    public static bool paused;
    public Button soundbtn,Musicbtn;
    // Start is called before the first frame update
    void Start()
    {
        background = Resources.Load<AudioClip>("bensound-scifi");
        pausebutton.SetActive(true);
        panel.SetActive(false);
        paused = false;
        audio.PlayOneShot(background);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PauseGame()
    {
        if (!paused)
        {
            paused = true;
            panel.SetActive(true);
            pausebutton.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void PlayGame()
    {
        if (paused)
        {
            paused = false;
            panel.SetActive(false);
            pausebutton.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public void GoToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
    public void SoundSystem()
    {
        if (OptionManager.soundon)
        {
            OptionManager.soundon = false;
        }
        else
        {
            OptionManager.soundon = true;
        }
    }
    public void MusicSystem()
    {
        if (OptionManager.musicon)
        {
            OptionManager.musicon = false;
            audio.Stop();
           
        }
        else
        {
            OptionManager.musicon = true;
            audio.PlayOneShot(background);
        }
    }

}
