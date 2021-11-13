using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAfterTime : MonoBehaviour
{
    public float startTime;
    float timer;

    private void Awake()
    {
        timer = startTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }
}
