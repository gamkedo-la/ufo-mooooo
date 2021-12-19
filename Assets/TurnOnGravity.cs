using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnGravity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ship" || other.tag == "Player")
        {
            this.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
