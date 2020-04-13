using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public static AudioClip background,explosion,shoot;
    static AudioSource audio;

   
    private void Awake()
    {
        explosion = Resources.Load<AudioClip>("Explosion");
        shoot = Resources.Load<AudioClip>("PlayerShoot");
        audio = GetComponent<AudioSource>();
    }


    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Explosion":
                if (OptionManager.soundon)
                {
                    audio.PlayOneShot(explosion);

                }
                break;
            case "PlayerShoot":
                if (OptionManager.soundon)
                {
                    audio.PlayOneShot(shoot);
                }
                break;
        }
    }
}
