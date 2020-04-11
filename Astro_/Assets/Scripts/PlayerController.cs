using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rigidbody;
    [Range(10, 30)]
    public float speed,tilt;
    public GameObject bolt;
    public Boundry boundry;
    public GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        speed = 20;
        tilt = 1;
        rigidbody.rotation = Quaternion.Euler(-90.0f, 0.0f,0.0f);

    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bolt, spawns[0].transform.position, spawns[0].transform.rotation);
            Instantiate(bolt, spawns[1].transform.position, spawns[1].transform.rotation);
            SoundManager.PlaySound("PlayerShoot");
        }
    }

    // Update is called once per fram e
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = movement*speed;

        rigidbody.position = new Vector3(
            Mathf.Clamp(rigidbody.position.x,boundry.xMin,boundry.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, boundry.zMin, boundry.zMax)
            );
        rigidbody.rotation = Quaternion.Euler(-90 , 0.0f, rigidbody.velocity.x * tilt);
    }
}

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;

}