using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{

  
    public void LoadA(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
