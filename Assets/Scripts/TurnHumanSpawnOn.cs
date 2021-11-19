using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHumanSpawnOn : MonoBehaviour
{
    public GameObject[] humanSpawns;
    float softCountdown, startTimer = 15f;


    private void Start()
    {
        softCountdown = startTimer;
        for (int i = 0; i < humanSpawns.Length; i++)
        {
            humanSpawns[i].SetActive(false);
        }
    }

    private void Update()
    {
        softCountdown -= Time.deltaTime;
        if (softCountdown <= 0)
        {
            ChooseHumanLocation();
        }
    }

    public void ChooseHumanLocation()
    {
        int locationToChoose = Random.Range(0, humanSpawns.Length);

        humanSpawns[locationToChoose].SetActive(true);
        softCountdown = startTimer;
        this.GetComponent<TurnHumanSpawnOn>().enabled = false;
    }
}
