using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{

    static OptionManager optionManager;

    private void Awake()
    {
        optionManager = GameObject.FindObjectOfType<OptionManager>();

    }
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
    public static void StopAudio()
    {
        optionManager.StopAudio();
    }
    
}
