using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    static Text score;
    static float counter;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        counter = 0;
        score.text=counter.ToString();
    }

    public static void UpdateScore()
    {
        counter+=15;
        score.text = counter.ToString();
    }

    public static Text getScore()
    {
        return score;
    }
}
