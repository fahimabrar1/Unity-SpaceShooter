using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolRecycler : MonoBehaviour
{
/*---------------------------------------------------------------------------------
 ----------------------------------------------------------------------------------

 This Script ReEnqueues the Bolt,Asteroid and Bluebolts when they hot the collider in the Background.

 ----------------------------------------------------------------------------------
 ---------------------------------------------------------------------------------*/

    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals("bolt"))
        {
            PlayerController.reEnque(other.gameObject);
        }else if (other.gameObject.tag.Equals("bluebolt"))
        {
            Boss.reEnque(other.gameObject);
        }
        else if (other.gameObject.tag.Equals("asteriod"))
        {
            GameHazard.reEnque(other.gameObject);
        }
    }
}
