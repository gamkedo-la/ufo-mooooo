using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string LevelToLoad;

    public bool CtoF1, CtoI1, CtoD1, CtoC1;

    public bool isCountdown;
    public float countDown;

    public void LevelLoad()
    {
        SceneManager.LoadScene(LevelToLoad);

        if (CtoF1)
        {
            GameManager.tempCtoF1 = true;
        }

        if (CtoI1)
        {
            GameManager.tempCtoI1 = true;
        }

        if (CtoD1)
        {
            GameManager.tempCtoD1 = true;
        }

        if (CtoC1)
        {
            GameManager.tempCtoC1 = true;
        }
    }

    private void Update()
    {
        if (isCountdown)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("MainMenu");
            }

            countDown -= Time.deltaTime;

            if (countDown <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
