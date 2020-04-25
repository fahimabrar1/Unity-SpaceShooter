using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{

 /*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 In this Script a giant Space Ship appears and takes a fight with our player after they reach a certain score.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/

    Transform transform;
    Rigidbody rigidbody;
    bool bossSpawned, reached, alive, missileactive;
    public GameObject bluebolt,missile;
    float xMax, xMin;
    public Transform[] boltSpawner;
    
    Transform player;
    public Slider slider;
    static float damage;

    //Queue for Bolt
    public static Queue<GameObject> boltqueue;


    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("ship").GetComponent<Transform>();
        missileactive = false;
        damage = 0.001f;
        xMax = 36;
        xMin = -36;
        transform = GetComponent<Transform>();
        reached = false;
        rigidbody = GetComponent<Rigidbody>();
        bossSpawned = false;
        alive = true;
        slider.value = 1;
        slider.gameObject.SetActive(false);
        boltqueue = new Queue<GameObject>();
        
        //Pushing all the bolts in the Queue
        
        for (int i = 0; i < 250; i++)
        {
            GameObject obj = Instantiate(bluebolt);
            obj.transform.parent = GameObject.FindGameObjectWithTag("BoltCollector").transform;
            obj.SetActive(false);
            boltqueue.Enqueue(obj);
        }
    }

/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

Update Funtion is Getting the Score Continuosly and lets the Move On Action with our player.
After Boss health is half , it lunches missiles on players position.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/
    void Update()
    {
        if(slider.value <0.5)
        {
            boltSpawner[0].LookAt(player.transform.position);
            boltSpawner[1].LookAt(player.transform.position);
            boltSpawner[2].LookAt(player.transform.position);
            if (!missileactive)
            {
                missileactive = true;
                StartCoroutine(MissileFire());
            }
        }

        if (ScoreSystem.getScoreCount() > 4500)
        {
            if (!bossSpawned)
            {
                bossSpawned = true;
                GameHazard.playeralive = false;
                Debug.Log(ScoreSystem.getScoreCount());
                StartCoroutine(Mover());
                MoveToAction();
            }
        }
    }

/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

In Mover() Boss moves and gets in positon to fight with our player.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/

    IEnumerator Mover()
    {
        Vector3 move = new Vector3(0, 0, -1);
        while (!reached)
        {
            Debug.Log("Moving");
            
            rigidbody.velocity = move * 6;
            yield return new WaitForSeconds(0.02f);
            if (transform.position.z < 60)
            {
                Debug.Log("Break");
                reached=true;
                slider.gameObject.SetActive(true);
                slider.value = 1f;
            }
        }
        rigidbody.velocity = move*0;
    }


/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

After Boss has reached to a stable position, it called MoveToAction() whichs Calls Action() funtion and 
allows our Boss to shoot Bolt Randomly at the Pplayer.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/

    private void MoveToAction()
    {
        StartCoroutine(Action());
    }
    IEnumerator Action()
    {
       
        
        while (alive)
        {
            float xPos = UnityEngine.Random.Range(xMin,xMax);
            GameObject obj = boltqueue.Dequeue();
            Rigidbody rg = obj.GetComponent<Rigidbody>();
            rg = obj.GetComponent<Rigidbody>();
            rg.velocity = obj.transform.forward * -20;
            obj.SetActive(true);

            obj.transform.position = boltSpawner[3].transform.position;

            obj.transform.rotation = Quaternion.Euler(0,180,0);

            boltSpawner[3].transform.position=new Vector3(xPos, boltSpawner[3].transform.position.y, boltSpawner[3].transform.position.z);
            yield return new WaitForSeconds(0.4f);
        }
    }


/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

When Boss health is below half, MissileFire is Called and shooted Missiles on the last Position Locked

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/


    IEnumerator MissileFire()
    {
        if (slider.value < 0.9)
        {

            while (alive)
            {
                int randspawn = UnityEngine.Random.Range(0,2);

                Rigidbody rg;
                GameObject obj = Instantiate(missile,boltSpawner[randspawn].position,boltSpawner[randspawn].rotation);
                rg = obj.GetComponent<Rigidbody>();
                rg.velocity = obj.transform.forward * 20;

                int rand = UnityEngine.Random.Range(1, 3);
                yield return new WaitForSeconds(rand);
            }
        }
    }

 /*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

Damage() funtion is Called Whenever Boss is hit By a bolt.
It is called From Destroyer Funtion().

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/
    public void Damage()
    {
        if (slider.value > 0)
        {
            slider.value -= damage;
            if(slider.value <=0)
            {
                alive = false;
                MenuManager.WinMenu();
                gameObject.SetActive(false);
                SoundManager.PlaySound("Explosion");
            }
        }
        
    }
    public static void reEnque(GameObject gameObject)
    {
        Rigidbody rg = gameObject.GetComponent<Rigidbody>();
        Transform t = gameObject.GetComponent<Transform>();
        t.rotation = Quaternion.Euler(Vector3.zero);
        rg.velocity = Vector3.zero;
        gameObject.SetActive(false);
        boltqueue.Enqueue(gameObject);
    }
}

