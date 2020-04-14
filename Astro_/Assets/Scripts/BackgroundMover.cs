using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    Rigidbody bg;
    float xMin = -5, xMax = 5;
    float zMin = 5, zMax = 10;
    private void Awake()
    {
        bg = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        bg.velocity = movement * 2;

        bg.position = new Vector3(
            Mathf.Clamp(bg.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(bg.position.z, zMin, zMax)
            );
    }
}
