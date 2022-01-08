using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetachCows : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            this.transform.DetachChildren();
        }
    }
}
