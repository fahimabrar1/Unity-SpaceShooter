using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissile : MonoBehaviour
{
  /*---------------------------------------------------------------------------------
  ----------------------------------------------------------------------------------

  In this Script is Responsible for Homing Missile.

  ----------------------------------------------------------------------------------
  ---------------------------------------------------------------------------------*/


    GameObject obj;
    Transform transform;
    Rigidbody rg;
    private void Start()
    {
        rg = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        obj = null;

    }
    
    //  When a Missile first tracked an asteroid in it's collider , it stores that
    //  asteroid only even after another asteroids enter into the collider.

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

    //Destroyes itself when hit with the box collider in the background image.

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("boundry"))
        {
            Destroy(gameObject);
        }
    }

    //FixedUpdate() function is responsible for the missile to move forward.
    //            it also follow and rotates towards the asteroid in radius.


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
