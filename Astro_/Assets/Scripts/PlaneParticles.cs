using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneParticles : MonoBehaviour
{
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
