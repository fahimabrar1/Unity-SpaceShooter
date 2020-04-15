using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
   
    public GameObject panel,pausebutton,death;
    public static bool paused;
    public static bool planealive;
    // Start is called before the first frame update
    void Start()
    {
        pausebutton.SetActive(true);
        panel.SetActive(false);
        death.SetActive(false);
        paused = false;
        planealive = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!planealive)
        {
            PauseGame();
        }
    }
    
    public void PauseGame()
    {
        if (!paused && planealive)
        {
            paused = true;
            panel.SetActive(true);
            pausebutton.SetActive(false);
            Time.timeScale = 0;
        }else if(!paused && !planealive)
        {
            death.SetActive(true);
        }
    }
    public void PlayGame()
    {
        if (paused && planealive)
        {
            paused = false;
            panel.SetActive(false);
            pausebutton.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public static void DeadMenu()
    {
        planealive = false;
    }
    public void RestartGame()
    {
        HomeScreenManager.StopAudio();
        SceneManager.LoadScene("Play");
    }
    public void GoToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
    public void setScore()
    {

        Text score = ScoreSystem.getScore();
    }
   
}
