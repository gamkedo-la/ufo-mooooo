using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLevelOrbOn : MonoBehaviour
{
    public GameObject[] orbs;

    public bool CtoF1, F1toF2, F2toC,
                CtoI1, I1toI2, I2toC,
                CtoD1, D1toD2, D2toC,
                CtoC1, C1toC2;

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

        if (CtoF1)
        {
            GameManager.CtoF1 = true;
        }

        if (F1toF2)
        {
            GameManager.F1toF2 = true;
        }

        if (F2toC)
        {
            GameManager.F2toC = true;
        }

        if (CtoI1)
        {
            GameManager.CtoI1 = true;
        }

        if (I1toI2)
        {
            GameManager.I1toI2 = true;
        }

        if (I2toC)
        {
            GameManager.I2toC = true;
        }

        if (CtoD1)
        {
            GameManager.CtoD1 = true;
        }

        if (D1toD2)
        {
            GameManager.D1toD2 = true;
        }

        if (D2toC)
        {
            GameManager.D2toC = true;
        }

        if (CtoC1)
        {
            GameManager.CtoC1 = true;
        }

        if (C1toC2)
        {
            GameManager.C1toC2 = true;
        }
    }
}
