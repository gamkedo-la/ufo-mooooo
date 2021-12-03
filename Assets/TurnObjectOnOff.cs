using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnObjectOnOff : MonoBehaviour
{
    public GameObject[] toTurnOn;
    public GameObject[] toTurnOff;

    bool startCountdown;
    public float delay;

    private void Update()
    {
        if (startCountdown)
        {
            delay -= Time.deltaTime;

            if (delay <= 0)
            {
                for (int i = 0; i < toTurnOn.Length; i++)
                {
                    toTurnOn[i].SetActive(true);
                }

                for (int i = 0; i < toTurnOff.Length; i++)
                {
                    toTurnOff[i].SetActive(false);
                }
            }
        }
    }

    public void ButtonPress()
    {
        startCountdown = true;
    }
}
