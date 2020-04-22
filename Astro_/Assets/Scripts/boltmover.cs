using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boltmover : MonoBehaviour
{
    Rigidbody rigidbody;
    public static int speed;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
    
}
