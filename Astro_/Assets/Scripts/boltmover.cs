using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltmover : MonoBehaviour
{
/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 In this Script Bolt we are making the Bolt move forward(Z-axis) with a constant speed.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/
    Rigidbody rigidbody;
    public static int speed;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
    
}
