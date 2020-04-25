using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
/*---------------------------------------------------------------------------------
----------------------------------------------------------------------------------

In this Script Boss Takes Damage When gets hit by Player's bolt or missiles.
If the Player somehow hits the boss, the player dies.

----------------------------------------------------------------------------------
---------------------------------------------------------------------------------*/
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
