using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    public GameObject[] objectToSpawn;
    public float timer, minTimer, maxTimer;

    private void Start()
    {
        timer = Random.Range(minTimer, maxTimer);
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            int chooseRandomObj = Random.Range(0,objectToSpawn.Length);
            Instantiate(objectToSpawn[chooseRandomObj]);
            timer = Random.Range(minTimer, maxTimer);
        }
    }
}
