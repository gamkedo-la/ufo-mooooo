using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocket : MonoBehaviour
{
    public Transform emissionPoint;
    public GameObject rocket;

    public float countDowntimerMin = 5f, countDowntimerMax = 10f, currentCountdownTimer;


    void Start()
    {
        currentCountdownTimer = Random.Range(countDowntimerMin, countDowntimerMax);
    
    }
    void Update()
    {
        currentCountdownTimer -= Time.deltaTime;
        if (currentCountdownTimer <= 0)
        {
            Instantiate(rocket, emissionPoint.transform.position, emissionPoint.rotation);
            currentCountdownTimer = Random.Range(countDowntimerMin, countDowntimerMax);
        }
    }
}
