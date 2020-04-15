﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [Range(10, 30)]
    public float speed,tilt;
    public GameObject bolt,Paricle;
    public Boundry boundry;
    public GameObject[] spawns;
    Touch touch;
    Vector3 vector,direction;
    bool fire;
    //Object Pulling

    public static Queue<GameObject> boltqueue;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        boltqueue = new Queue<GameObject>();
        for (int i = 0; i < 100; i++)
        {
            GameObject obj = Instantiate(bolt);
            obj.SetActive(false);
            boltqueue.Enqueue(obj);
        }
        speed = 20;
        tilt = 1;
        fire = false;

        StartCoroutine(UPDATE());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !MenuManager.paused)
        {
            gefromBoltQueue();
            SoundManager.PlaySound("PlayerShoot");
        }
    }

    IEnumerator UPDATE()
    {
        while (true)
        {
            if (fire)
            {
                if (!MenuManager.paused)
                {
                    gefromBoltQueue();
                    SoundManager.PlaySound("PlayerShoot");
                }
            }

            yield return new WaitForSeconds(0.4f);
        }
    }
   
    // Update is called once per fram e
    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            if (!fire)
            {
                fire=true;
            }
            
            Touch touch = Input.GetTouch(0);
                vector = Camera.main.ScreenToWorldPoint(touch.position);
                vector.y = 0;
                vector.z = vector.z + 8;
                Debug.Log(vector);
                direction = (vector - transform.position);
                rigidbody.velocity = new Vector3(direction.x, 0, direction.z) * speed;
                rigidbody.position = new Vector3(
                Mathf.Clamp(rigidbody.position.x, boundry.xMin, boundry.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundry.zMin, boundry.zMax)
                );
                rigidbody.rotation = Quaternion.Euler(0, 0.0f, -rigidbody.velocity.x / 3 * tilt);
                if (touch.phase == TouchPhase.Ended)
                {
                    rigidbody.velocity = Vector3.zero;
                }

        }
        else
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            if (fire)
            {
                fire = false;
            }

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            rigidbody.velocity = movement * speed;

            rigidbody.position = new Vector3(
                Mathf.Clamp(rigidbody.position.x, boundry.xMin, boundry.xMax),
                0.0f,
                Mathf.Clamp(rigidbody.position.z, boundry.zMin, boundry.zMax)
                );
            rigidbody.rotation = Quaternion.Euler(0, 0.0f, -rigidbody.velocity.x * tilt);
            Paricle.transform.position = gameObject.transform.position;
        }    
    }



    public void gefromBoltQueue()
    {
        GameObject obj = boltqueue.Dequeue();
        GameObject obj1 = boltqueue.Dequeue();
        obj.SetActive(true);
        obj1.SetActive(true);

        obj.transform.position = spawns[0].transform.position;
        obj1.transform.position = spawns[1].transform.position;

        obj.transform.rotation = spawns[0].transform.rotation;
        obj1.transform.rotation = spawns[1].transform.rotation;
    }
    public static void reEnque(GameObject gameObject)
    {
        gameObject.SetActive(false);
        boltqueue.Enqueue(gameObject);
    }

}

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;

}