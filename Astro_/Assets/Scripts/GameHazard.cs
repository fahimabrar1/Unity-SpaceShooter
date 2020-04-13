using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHazard : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public static bool playeralive;

    //Object Pulling

    public static Queue<GameObject> astros;

    // Start is called before the first frame update
    void Start()
    {
        astros = new Queue<GameObject>();
        for (int i = 0; i < 40; i++)
        {
            
            GameObject obj =Instantiate(hazard);
            obj.SetActive(false);
            astros.Enqueue(obj);
        }
        playeralive = true;
        spawnwaves();
    }

    private void spawnwaves()
    {
        StartCoroutine(HazardsFromPool());
    }

    IEnumerator HazardsFromPool()
    {
        yield return new WaitForSeconds(1.0f);
        while (playeralive)
        {
            Vector3 spawnpositions = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
            Quaternion spawnRotaion = new Quaternion();
            GameObject obj = astros.Dequeue();
            obj.transform.position = spawnpositions;
            obj.transform.rotation = spawnRotaion;
            obj.SetActive(true);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 1));
        }

    }
    public static void reEnque(GameObject gameObject)
    {
        gameObject.SetActive(false);
        astros.Enqueue(gameObject);
    }
   
}
