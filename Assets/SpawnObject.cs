using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public Vector3 locationToSpawn;
    public GameObject objectToSpawn;

    public void CreateObject()
    {
        Instantiate(objectToSpawn, locationToSpawn, transform.rotation);
    }
}
