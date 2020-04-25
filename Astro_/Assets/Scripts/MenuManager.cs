using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

        This Script is Responsible To Handle the in game UI.
        It also assigns the player stats before it spawns.
 
 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/
    public GameObject panel,pausebutton,death,win;
    public static bool paused;
    public GameObject[] Ship;
    public static bool planealive, setFinalScore, bossalive;
    public Text score;
    string getscore;

    // Start is called before the first frame update
    void Start()
    {
        pausebutton.SetActive(true);
        panel.SetActive(false);
        win.SetActive(false);
        death.SetActive(false);
        paused = false;
        setFinalScore = false;
        planealive = true;
        bossalive = true;
        Time.timeScale = 1;

//It Checks Which Craft is Selected by players and what are it's active abilities.
        
        if (PlayerPrefs.GetInt("craft") == 0)
        {
            PlayerController.CraftSetup(PlayerPrefs.GetInt("Heli_LB"), PlayerPrefs.GetInt("Heli_BA"), PlayerPrefs.GetInt("Heli_MM"));
            Instantiate(Ship[0], Ship[0].transform.position, Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("craft") == 1)
        {
            PlayerController.CraftSetup(PlayerPrefs.GetInt("SpaceShip_LB"),PlayerPrefs.GetInt("SpaceShip_BA"),PlayerPrefs.GetInt("SpaceShip_MM"));
            Instantiate(Ship[1], Ship[1].transform.position, Quaternion.identity);
        }
        else if (PlayerPrefs.GetInt("craft") == 2)
        {
            PlayerController.CraftSetup(PlayerPrefs.GetInt("Corvette_LB"),PlayerPrefs.GetInt("Corvette_BA"),PlayerPrefs.GetInt("Corvette_MM"));
            Instantiate(Ship[2], Ship[2].transform.position, Quaternion.identity);
        }
    }

 //It Sets The UI Scores And Which Panel To get Active According how Player Died or Win

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
        }else if (planealive && !bossalive)
        {
            if (!setFinalScore)
            {
                setFinalScore = true;

                setScore();
            }
            PauseGame();
        }
    }
 
//PauseGame() is responsible to Active The panels Based on Player. Either Paused or Dead or Winn
    
    public void PauseGame()
    {
        //Win Panel
        if (!paused && !bossalive && planealive)
        {
            score.text = getscore;
            win.SetActive(true);
        }
        //Death Panel
        else if(!paused && !planealive && bossalive)
        {
            score.text = getscore;
            death.SetActive(true);
        }
        //Pause Panel
        else if (!paused && planealive)
        {
            paused = true;
            panel.SetActive(true);
            pausebutton.SetActive(false);
            Time.timeScale = 0;
        }
    }
//PlayeGame() funtion Resumes The Game.

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

//sets if players is dead.

    public static void DeadMenu()
    {
        planealive = false;
    }

    //WinMenu() funtion sets if boss is dead.

    public static void WinMenu()
    {
        bossalive = false;
    }

    // RestartGame() funtion Restarts the game.

    public void RestartGame()
    {
        HomeScreenManager.StopAudio();
        SceneManager.LoadScene("Play");
    }

    //GoToHome() funtion Unpausing the moment and Going home.

    public void GoToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }

    //setScore() funtion Gets the Score from score system


    public void setScore()
    {
        getscore = ScoreSystem.getScore().text;
    }
   
}
