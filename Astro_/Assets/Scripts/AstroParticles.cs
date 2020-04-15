using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroParticles : MonoBehaviour
{
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
