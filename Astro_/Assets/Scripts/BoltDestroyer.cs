using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltDestroyer : MonoBehaviour
{
    Mover mover;
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
