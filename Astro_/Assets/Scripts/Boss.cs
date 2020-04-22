using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    Transform transform;
    Rigidbody rigidbody;
    bool bossSpawned, reached, alive;

    float xMax, xMin;
    public GameObject[] boltSpawner;
    public GameObject Laser;
    public Slider slider;
    static float damage;

    // Start is called before the first frame update
    void Start()
    {
        
        damage = 0.001f;
        xMax = 36;
        xMin = -36;
        transform = GetComponent<Transform>();
        reached = false;
        rigidbody = GetComponent<Rigidbody>();
        bossSpawned = false;
        alive = true;

        slider.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ScoreSystem.getScoreCount() > 45)
        {
            if (!bossSpawned)
            {
                bossSpawned = true;
                Debug.Log(ScoreSystem.getScoreCount());
                StartCoroutine(Mover());
                MoveToAction();
            }
        }
    }

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

    private void MoveToAction()
    {
        StartCoroutine(Action());
    }
    IEnumerator Action()
    {

        while (alive)
        {
            float xPos = UnityEngine.Random.Range(xMin,xMax);
            GameObject obj = PlayerController.boltqueue.Dequeue();
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
    void BurstFire()
    {

    }
    public void Damage()
    {
        if (slider.value > 0)
        {
            slider.value -= damage;
        }
        else
        {
            alive = false;
            gameObject.SetActive(false);
            SoundManager.PlaySound("Explosion");
        }
    }
    void AngularBurstFire()
    {

    }
}

