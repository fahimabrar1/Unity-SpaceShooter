using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeScreenManager : MonoBehaviour
{
    public Image Craft;
    public Sprite[] CraftSprites;
    public GameObject[] Ship;
    static OptionManager optionManager;
    int i = 0;
    private void Awake()
    {
        optionManager = GameObject.FindObjectOfType<OptionManager>();

    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Home"))
        {
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
        if (SceneManager.GetActiveScene().name.Equals("Play"))
        {
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
    }
    public void NextCraft()
    {
      
        if (i < 3)
        {
            i++;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
        else
        {
            i = 0;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
    }
    public void PrevCraft()
    {
      
        if (i > 0)
        {
            i--;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
        else
        {
            i = 2;
            Craft.sprite = CraftSprites[i];
            PlayerPrefs.SetInt("craft", i);
        }
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
