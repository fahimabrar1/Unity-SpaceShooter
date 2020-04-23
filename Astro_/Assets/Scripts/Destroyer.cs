using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("bolt"))
        {
            Boss boss = FindObjectOfType<Boss>();
            boss.Damage();
            //Bolt Queuing
            PlayerController.reEnque(other.gameObject);
            SoundManager.PlaySound("Explosion");
        }
        else if (other.gameObject.tag.Equals("misssile"))
        {
            Boss boss = FindObjectOfType<Boss>();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            boss.Damage();
            //Bolt Queuing
            Destroy(other.gameObject);
            SoundManager.PlaySound("Explosion");
        }
        else if (other.gameObject.tag.Equals("ship"))
        {
            MenuManager.DeadMenu();
            PlaneParticles.Particles();
            Debug.Log(other.gameObject.tag);
            other.gameObject.SetActive(false);
            SoundManager.PlaySound("Explosion");
            GameHazard.playeralive = false;
        }
    }
}
