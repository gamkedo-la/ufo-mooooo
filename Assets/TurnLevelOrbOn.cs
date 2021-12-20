using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLevelOrbOn : MonoBehaviour
{
    public GameObject[] orbs;

    private void Start()
    {
        StartCoroutine(TurnOn());
    }

    IEnumerator TurnOn()
    {
        for (int i = 0; i < orbs.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            orbs[i].SetActive(true);
        }
    }
}
