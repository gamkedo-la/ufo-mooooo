using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreator : MonoBehaviour
{
    public GameObject objToCreate;
    public int objToCreateCount = 100;
    public float minX, maxX, minY, maxY, minZ, maxZ;

    void Start()
    {
        for (int i = 0; i < objToCreateCount; i++)
        {
            float X = Random.Range(minX, maxX);
            float Y = Random.Range(minY, maxY);
            float Z = Random.Range(minZ, maxZ);
            Instantiate(objToCreate, new Vector3(X, Y, Z), transform.rotation);
            objToCreateCount--;
        }
    }
}
