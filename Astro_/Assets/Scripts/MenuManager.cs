using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
   
    public GameObject panel,pausebutton,death;
    public static bool paused;
    public GameObject[] Ship;
    public static bool planealive, setFinalScore;
    public Text score;
    string getscore;
    // Start is called before the first frame update
    void Start()
    {
        pausebutton.SetActive(true);
        panel.SetActive(false);
        death.SetActive(false);
        paused = false;
        setFinalScore = false;
        planealive = true;
        Time.timeScale = 1;
        if (PlayerPrefs.GetInt("craft", 0) == 0)
        {
            Instantiate(Ship[0], Ship[0].transform.position, Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("craft", 1) == 1)
        {
            Instantiate(Ship[1], Ship[1].transform.position, Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("craft", 2) == 2)
        {
            Instantiate(Ship[2], Ship[2].transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!planealive)
        {
            if (!setFinalScore)
            {
                setFinalScore = true;

                setScore();
            }
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
            score.text = getscore;
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
        getscore = ScoreSystem.getScore().text;
    }
   
}
