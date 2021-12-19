using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHuman : MonoBehaviour
{
    public Transform humanLocation;
    public GameObject humanSpawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Human")
        {           
            Destroy(other.gameObject);
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        Instantiate(humanSpawn, humanLocation.transform.position, Quaternion.identity);
    }
}
