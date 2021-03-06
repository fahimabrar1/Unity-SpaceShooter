﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMissiles : MonoBehaviour
{
    
    
/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

In this Script Boss Missiles Are Destroyed When hit's the Boundry and Plane.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("ship"))
        {
            MenuManager.DeadMenu();
            PlaneParticles.Particles();
            other.gameObject.SetActive(false);
            Destroy(gameObject);
            SoundManager.PlaySound("Explosion");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("boundry"))
        {
            Destroy(gameObject);
        }
    }
}
