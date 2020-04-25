using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 This Script is Responsible To rotate Asteroid Randomly.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/
   
    Rigidbody rigidbody;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * Random.Range(1,6);
    }
    

}

