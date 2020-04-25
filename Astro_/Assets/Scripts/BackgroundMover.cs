using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{

/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

        In this Script, Background Image is Moved Acoording to The Ship/Plane movement.
        It is Also also Clamped Slightly To make is more realistic.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/



    Rigidbody bg;
    float xMin = -5, xMax = 5;
    float zMin = 5, zMax = 10;
    private void Awake()
    {
        bg = GetComponent<Rigidbody>();
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
