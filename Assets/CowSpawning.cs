using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowSpawning : MonoBehaviour
{
    public GameObject cow, goldCow;

    public float timerToCreate;
    public float timerMin, timerMax;
    public int minCows, maxCows;
    public int cowsToCreate;

    public float percentForGoldCow = 10f;

    public Transform minX, maxX, minZ, maxZ;
    public float minY, maxY;

    private void Start()
    {
        timerToCreate = Random.Range(timerMin, timerMax);

        cowsToCreate = Random.Range(minCows, maxCows);
    }

    private void Update()
    {
        timerToCreate -= Time.deltaTime;

        if (timerToCreate <= 0)
        {
            CreateCows();
        }
    }

    void CreateCows()
    {
        for (int i = 0; i < cowsToCreate; i++)
        {
            float WhichCowToSpawn = Random.Range(0, 100);

            if (WhichCowToSpawn <= percentForGoldCow)
            {
                Instantiate(goldCow, new Vector3(Random.Range(minX.transform.position.x, maxX.transform.position.x), Random.Range(minY, maxY), Random.Range(minZ.transform.position.z, maxZ.transform.position.z)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
            else if(WhichCowToSpawn >= percentForGoldCow)
            {
                Instantiate(cow, new Vector3(Random.Range(minX.transform.position.x, maxX.transform.position.x), Random.Range(minY, maxY), Random.Range(minZ.transform.position.z, maxZ.transform.position.z)), Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
            cowsToCreate--;
        }

        cowsToCreate = Random.Range(minCows, maxCows);
        timerToCreate = Random.Range(timerMin, timerMax);
    }
}
