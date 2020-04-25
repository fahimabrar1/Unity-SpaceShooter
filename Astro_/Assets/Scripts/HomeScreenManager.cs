using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{
/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

Hoome Manager Is responsible To Change between Scenes Through Buttons.


----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/

    static OptionManager optionManager;
    private void Awake()
    {
        optionManager = GameObject.FindObjectOfType<OptionManager>();
    }
   
//LoadA() funtions takes a parameter as a string, and loads the Scene, If the Scene is Home it will turn off the Audio.

    public void LoadA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        if (scenename.Equals("Home"))
        {
            optionManager.StopAudio();
        }
        SceneManager.LoadScene(scenename);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

//This Stop Audio is called From MenuManager in the Play Scene, it is Responsible to Stop the music while playing the game.
    public static void StopAudio()
    {
        optionManager.StopAudio();
    }
    
}
