using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroParticles : MonoBehaviour
{
    /*---------------------------------------------------------------------------------
     ----------------------------------------------------------------------------------
     
     In this Script Asteroid Particles are emitted.
     Whenever an asteroid is Destroyed , It's Position is sent in Astro(Transform ass), and this Funtions Plays The ParticleSystem On that Position.

     ----------------------------------------------------------------------------------
     ---------------------------------------------------------------------------------*/


    // Start is called before the first frame update
    static ParticleSystem ParticleSystem;
    private void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }


    public static void Astro(Transform ass)
    {
        ParticleSystem.transform.position = ass.position;
        ParticleSystem.Play();
    }
}
