using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
   

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bolt"))
        {
            GameHazard.reEnque(gameObject);
            PlayerController.reEnque(other.gameObject);
            SoundManager.PlaySound("Explosion");
            ScoreSystem.UpdateScore();
        }else if (other.gameObject.tag.Equals("ship"))
        {
            GameHazard.reEnque(gameObject);
            SoundManager.PlaySound("Explosion");

            Destroy(other.gameObject);
            SoundManager.PlaySound("Explosion");

            GameHazard.playeralive = false;
        }
    }
}
