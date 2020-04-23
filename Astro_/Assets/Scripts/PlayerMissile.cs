using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
    GameObject obj;
    Transform transform;
    Rigidbody rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        obj = null;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("asteriod"))
        {
            if (obj == null)
            {
                obj = other.gameObject;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("boundry"))
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        if (obj != null)
        {
            rg.velocity = obj.transform.position;
            transform.LookAt(obj.transform);
        }
        else
        {
            rg.velocity = transform.forward * 30;
        }
    }
}
