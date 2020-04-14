using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    // Start is called before the first frame update
    static ParticleSystem ParticleSystem;
    public Transform ship;
    private void Awake()
    {
        ParticleSystem = GetComponent<ParticleSystem>();
    }
   
  
    public static void PlaneParticles()
    {
        ParticleSystem.Play();
    }
   
}
