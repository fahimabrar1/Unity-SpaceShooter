using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip background,explosion,shoot;
    static AudioSource audio;
    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Explosion");
        shoot = Resources.Load<AudioClip>("PlayerShoot");
        background = Resources.Load<AudioClip>("bensound-scifi");

        audio = GetComponent<AudioSource>();

    }
    private void Start()
    {
        audio.PlayOneShot(background);

    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Explosion":
                audio.PlayOneShot(explosion);
                break;
            case "PlayerShoot":
                audio.PlayOneShot(shoot);
                break;
        }
    }
}
