using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

    This Script Controls The Behaivior Of the Ship.
    It Controls Movement, Tilt , shooting.
    Used Both Controls For Andround And Windows Platform.

        For Android , ship shoots continously while holding and draging through screen.
        For Windowns, ship shoots on Click and and moves on Axis.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/


    Rigidbody rigidbody;
    [Range(10, 35)]
    public float speed,tilt;
    public GameObject bolt,missileObj,Paricle;
    public Boundry boundry;
    public GameObject[] spawns;
    public Transform Missilespawn;
    Touch touch;
    Vector3 vector,direction;
    bool fire;
    static int boltController,missile, boltspeed;
    //Object Pulling

    private static Queue<GameObject> boltqueue;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("boltcount",4);
        boltqueue = new Queue<GameObject>();
        for (int i = 0; i < 250; i++)
        {
            GameObject obj = Instantiate(bolt);
            obj.transform.parent = GameObject.FindGameObjectWithTag("BoltCollector").transform;
            obj.SetActive(false);
            boltqueue.Enqueue(obj);
        }
       
        speed = 20;
        tilt = 1;
        fire = false;
        StartCoroutine(UPDATE());
        StartCoroutine(Missile());

    }

    //  Update() funtions is responsible for Shooting in Windows Platform.  

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !MenuManager.paused)
        {
            gefromBoltQueue();
            SoundManager.PlaySound("PlayerShoot");
        }
    }

    //  UPDATE() funtions is responsible for Shooting in Android Platform.

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

    //  Missile() funtions is responsible for Shooting Missiles From Both Platforms.

    IEnumerator Missile()
    {       
        Rigidbody rg,rg1,rg2;
        GameObject obj,obj1,obj2;
        while (true)
        {
            
            switch (missile)
            {
                case 1:
                    obj = Instantiate(missileObj);
                    rg = obj.GetComponent<Rigidbody>();

                    obj.transform.position = Missilespawn.position;
                    
                    obj.transform.rotation = Missilespawn.rotation;
                    rg.velocity = obj.transform.forward * 30;
                    yield return new WaitForSeconds(1);
                    
                    break;
                case 2:
                    obj = Instantiate(missileObj);
                    rg = obj.GetComponent<Rigidbody>();

                    obj.transform.position = Missilespawn.position;

                    obj.transform.rotation = Missilespawn.rotation;
                    rg.velocity = obj.transform.forward * 30;
                    yield return new WaitForSeconds(1);

                    obj1 = Instantiate(missileObj);
                    rg1 = obj1.GetComponent<Rigidbody>();

                    obj1.transform.position = Missilespawn.position;

                    obj1.transform.rotation = Missilespawn.rotation;
                    rg1.velocity = obj1.transform.forward * 30;
                    yield return new WaitForSeconds(1);


                    break;
                case 3:
                    obj = Instantiate(missileObj);
                    rg = obj.GetComponent<Rigidbody>();

                    obj.transform.position = Missilespawn.position;

                    obj.transform.rotation = Missilespawn.rotation;
                    rg.velocity = obj.transform.forward * 30;
                    yield return new WaitForSeconds(1);

                    obj1 = Instantiate(missileObj);
                    rg1 = obj1.GetComponent<Rigidbody>();

                    obj1.transform.position = Missilespawn.position;

                    obj1.transform.rotation = Missilespawn.rotation;
                    rg1.velocity = obj1.transform.forward * 30;
                    
                    
                    obj2 = Instantiate(missileObj);
                    rg2 = obj2.GetComponent<Rigidbody>();

                    obj2.transform.position = Missilespawn.position;

                    obj2.transform.rotation = Missilespawn.rotation;
                    rg2.velocity = obj2.transform.forward * 30;

                    break;

            }
            yield return new WaitForSeconds(8f);
        }
    }
   
    // FixedUpdate() function is Responsible For Movements in Both Platforms.

    void FixedUpdate()
    {
        //This Section Is Responsible for Android Touch Movement.
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
                rigidbody.velocity = new Vector3(direction.x, 0, direction.z) * speed *4*Time.deltaTime;
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
            //This Section Is Responsible for Windlwos Axis Movement.

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


    //getFromBoltQueue() funtion is responsible for Shooting the Bolt.
    //      it Dequeues from the Queue , set it's postion and rotation acoodring to the spawn
    //      position then moves forwards until it hits an asteroid or boss or Hit the Box 
    //      collider in the Background miage to reEnqueue to be reused.

    public void gefromBoltQueue()
    {
        GameObject obj, obj1, obj2, obj3, obj4;
        Rigidbody rg, rg1, rg2, rg3, rg4;
        switch (boltController) {
            case 1:
                obj = boltqueue.Dequeue();

                rg = obj.GetComponent<Rigidbody>();
                rg.velocity = obj.transform.forward * boltspeed;

                obj.SetActive(true);
                
                obj.transform.position = spawns[2].transform.position;
                
                obj.transform.rotation = spawns[2].transform.rotation;
               
                break;

            case 2:
                obj = boltqueue.Dequeue();
                obj1 = boltqueue.Dequeue();

                rg = obj.GetComponent<Rigidbody>();
                rg.velocity = obj.transform.forward * boltspeed;
                rg1 = obj1.GetComponent<Rigidbody>();
                rg1.velocity = obj1.transform.forward * boltspeed;
               
                obj.SetActive(true);
                obj1.SetActive(true);

                obj.transform.position = spawns[1].transform.position;
                obj1.transform.position = spawns[3].transform.position;

                obj.transform.rotation = spawns[1].transform.rotation;
                obj1.transform.rotation = spawns[3].transform.rotation;
                
                break;

            case 3:
                obj = boltqueue.Dequeue();
                obj1 = boltqueue.Dequeue();
                obj2 = boltqueue.Dequeue();

                rg = obj.GetComponent<Rigidbody>();
                rg.velocity = obj.transform.forward * boltspeed;
                rg1 = obj1.GetComponent<Rigidbody>();
                rg1.velocity = obj1.transform.forward * boltspeed;
                rg2 = obj2.GetComponent<Rigidbody>();
                rg2.velocity = obj2.transform.forward * boltspeed;

                obj.SetActive(true);
                obj1.SetActive(true);
                obj2.SetActive(true);

                obj.transform.position = spawns[1].transform.position;
                obj1.transform.position = spawns[2].transform.position;
                obj2.transform.position = spawns[3].transform.position;

                obj.transform.rotation = spawns[1].transform.rotation;
                obj1.transform.rotation = spawns[2].transform.rotation;
                obj2.transform.rotation = spawns[3].transform.rotation;
               
                break;

            case 4:
                obj = boltqueue.Dequeue();
                obj1 = boltqueue.Dequeue();
                obj2 = boltqueue.Dequeue();
                obj3 = boltqueue.Dequeue();
                obj4 = boltqueue.Dequeue();

                rg = obj.GetComponent<Rigidbody>();
                rg.velocity = obj.transform.forward * boltspeed;
                rg1 = obj1.GetComponent<Rigidbody>();
                rg1.velocity = obj1.transform.forward * boltspeed;
                rg2 = obj2.GetComponent<Rigidbody>();
                rg2.velocity = obj2.transform.forward * boltspeed; 
                rg3 = obj3.GetComponent<Rigidbody>();
                rg3.velocity = obj3.transform.forward * boltspeed;
                rg4 = obj4.GetComponent<Rigidbody>();
                rg4.velocity = obj4.transform.forward * boltspeed;

                obj.SetActive(true);
                obj1.SetActive(true);
                obj2.SetActive(true);
                obj3.SetActive(true);
                obj4.SetActive(true);

                obj.transform.position = spawns[0].transform.position;
                obj1.transform.position = spawns[1].transform.position;
                obj2.transform.position = spawns[2].transform.position;
                obj3.transform.position = spawns[3].transform.position;
                obj4.transform.position = spawns[4].transform.position;
               
                obj.transform.rotation = spawns[0].transform.rotation;
                obj1.transform.rotation = spawns[1].transform.rotation;
                obj2.transform.rotation = spawns[2].transform.rotation;
                obj3.transform.rotation = spawns[3].transform.rotation;
                obj4.transform.rotation = spawns[4].transform.rotation;
               
                break;
        }
        
    }

    //Destroyes The Ship when hit by blue Bolt shot by the boss.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bluebolt"))
        {
            MenuManager.DeadMenu();
            gameObject.SetActive(false); 
            PlaneParticles.Particles();
            GameHazard.playeralive = false;
            SoundManager.PlaySound("Explosion");
            other.gameObject.SetActive(false);
        }
    }

    //ReEnqueues The Destroued bolt in the scene.

    public static void reEnque(GameObject gameObject)
    {
        Rigidbody rg = gameObject.GetComponent<Rigidbody>();
        Transform t = gameObject.GetComponent<Transform>();
        t.rotation = Quaternion.Euler(Vector3.zero);
        rg.velocity= Vector3.zero;
        gameObject.SetActive(false);
        boltqueue.Enqueue(gameObject);
    }

    //Gets Ship's Ability at the begginning of the start.

    public static void CraftSetup(int LB , int BA , int MM)
    {
        boltController = LB;
        boltspeed = BA;
        missile = MM;
    }
}

[System.Serializable]
public class Boundry
{
    //This Class is Used to Make Boundry of the Screen for Ship.

    public float xMin, xMax, zMin, zMax;

}