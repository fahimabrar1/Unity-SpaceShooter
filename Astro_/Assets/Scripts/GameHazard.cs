using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHazard : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public static bool playeralive;
    // Start is called before the first frame update
    void Start()
    {
        spawnwaves();
        playeralive = true;
    }

    private void spawnwaves()
    {
        StartCoroutine(Hazards());
    }

    IEnumerator Hazards()
    {
        yield return new WaitForSeconds(1.0f);
        while (playeralive)
        {
            Vector3 spawnpositions = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotaion = new Quaternion();
            Instantiate(hazard, spawnpositions, spawnRotaion);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 1));
        }

    }
   
}
