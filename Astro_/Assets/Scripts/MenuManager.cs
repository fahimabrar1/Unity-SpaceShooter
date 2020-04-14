using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
   
    public GameObject panel,pausebutton,death;
    public static bool paused;
    public static bool plane;
    // Start is called before the first frame update
    void Start()
    {
        pausebutton.SetActive(true);
        panel.SetActive(false);
        death.SetActive(false);
        paused = false;
        plane = true;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PauseGame()
    {
        if (!paused && plane)
        {
            paused = true;
            panel.SetActive(true);
            pausebutton.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void PlayGame()
    {
        if (paused && plane)
        {
            paused = false;
            panel.SetActive(false);
            pausebutton.SetActive(true);
            Time.timeScale = 1;
        }
    }
    public static void DeadMenu()
    {
        
    }
    public static void RestartGame()
    {

    }
    public void GoToHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Home");
    }
   
   
}
