using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody rigidbody;
   
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
    
        if (gameObject.tag.Equals("asteriod"))
        {
            speed = -Random.Range(20, 35);
        }
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }
    
}
