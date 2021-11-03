using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public float minutes = 1, seconds = 30;
    public Text TimeRemaining;
    bool stopCountDown;
    public static int score, goldScore, humanScore, total;

    public Text cowsCollected, goldCollectedRaw, goldCollected, humanCollectedRaw, humanCollected, totalCollected;
    public int scoreStar1, scoreStar2, scoreStar3;
    public GameObject levelFinished, star1, star2, star3;
    public GameObject Continue;
    private void Start()
    {
        score = 0;
        goldScore = 0;
        humanScore = 0;
        total = 0;
    }

    void Update()
    {
        if (!stopCountDown)
        {
            seconds -= Time.deltaTime;
            if (seconds <= 10)
            {
                TimeRemaining.text = minutes + ":0" + seconds.ToString("F0");
            }
            else
            {
                TimeRemaining.text = minutes + ":" + seconds.ToString("F0");
            }

            if (seconds <= 0)
            {
                if (minutes <= 0 && seconds <= 0)
                {
                    TimeRemaining.text = "0:00";
                    stopCountDown = true;
                    print("Play end of level sound effect");
                    levelFinished.SetActive(true);
                    StartCoroutine(EndScreen());
                }
                else
                {
                    minutes--;
                    seconds = 59;

                    TimeRemaining.text = minutes + ":" + seconds.ToString("F0");
                }
            }        
        }
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(3);
        cowsCollected.text = score.ToString();

        goldCollectedRaw.text = goldScore.ToString();
        humanCollectedRaw.text = humanScore.ToString();

        goldCollected.text = (5 * goldScore).ToString();
        humanCollected.text = (-5 * humanScore).ToString();

        total = (score + (goldScore * 5) + (humanScore * -5));
        totalCollected.text = total.ToString(); 
        if (total >= scoreStar1)
        {
            yield return new WaitForSeconds(1);
            star1.SetActive(true);
        }
        if (total >= scoreStar2)
        {
            yield return new WaitForSeconds(1);
            star2.SetActive(true);
        }
        if (total >= scoreStar3)
        {
            yield return new WaitForSeconds(1);
            star3.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        Continue.SetActive(true);
    }

    public void ContinueButton()
    {
        score = 0;
        goldScore = 0;
        humanScore = 0;
        SceneManager.LoadScene("LevelSelect");
    }
}
