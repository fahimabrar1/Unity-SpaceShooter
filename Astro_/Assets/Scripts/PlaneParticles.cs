using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneParticles : MonoBehaviour
{
/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 In this Script Plane ParticleSystem is called whenever Player Dies.
 See the 4 references abobe Particles() function from where it is called.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/
    // Start is called before the first frame update
    static ParticleSystem ParticleSystem;
    private void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }


    public static void Particles()
    {
        ParticleSystem.Play();
    }
}
