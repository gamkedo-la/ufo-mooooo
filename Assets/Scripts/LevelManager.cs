using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public bool ignoreInitialLevelDelay;
    public float initialLevelDelay = 5f;
    bool roundStarted;

    public Animator countdownWindow;
    public Text countdownClock, countdownText;
    public GameObject countdownObject;

    public bool level1, level2, level3, level4, level5, level6, level7, level8;

    public float minutes = 1, seconds = 30;
    public Text TimeRemaining;
    bool stopCountDown;
    public static int score, goldScore, total;

    public Text cowsCollected, goldCollectedRaw, goldCollected, totalCollected;
    int scoreStar1, scoreStar2, scoreStar3;
    public GameObject levelFinished, star1, star2, star3;
    public GameObject Continue;
    public static GameObject gateOpenedUI;

    public AudioSource Country;

    public bool goToCredits;

    public GameObject player;
    public Text scoreText;
    private void Start()
    {
        GameManager.gateOpened = false;
        Country.volume = 0.3f; // mixing adjustment from code to apply to all levels, to make late sound additions easier to hear

        gateOpenedUI = GameObject.FindGameObjectWithTag("GateOpened");
        gateOpenedUI.SetActive(false);

        score = 0;
        goldScore = 0;
        total = 0;

        if (ignoreInitialLevelDelay)
        {
            initialLevelDelay = 0f;
        }
        else
        {
            initialLevelDelay = 5f;
        }

        stopCountDown = true;

        //This will need to be updated for multiplayers
        #region Determine Star Scores
        if (level1)        {
            scoreStar1 = GameManager.Level1Star1;
            scoreStar2 = GameManager.Level1Star2;
            scoreStar3 = GameManager.Level1Star3;
        }

        else if (level2)        {
            scoreStar1 = GameManager.Level2Star1;
            scoreStar2 = GameManager.Level2Star2;
            scoreStar3 = GameManager.Level2Star3;
        }

       else if (level3)        {
            scoreStar1 = GameManager.Level3Star1;
            scoreStar2 = GameManager.Level3Star2;
            scoreStar3 = GameManager.Level3Star3;
        }
        else if (level4)        {
            scoreStar1 = GameManager.Level4Star1;
            scoreStar2 = GameManager.Level4Star2;
            scoreStar3 = GameManager.Level4Star3;
        }
        else if (level5)
        {
            scoreStar1 = GameManager.Level5Star1;
            scoreStar2 = GameManager.Level5Star2;
            scoreStar3 = GameManager.Level5Star3;
        }
        else if (level6)
        {
            scoreStar1 = GameManager.Level6Star1;
            scoreStar2 = GameManager.Level6Star2;
            scoreStar3 = GameManager.Level6Star3;
        }
        else if (level7)
        {
            scoreStar1 = GameManager.Level7Star1;
            scoreStar2 = GameManager.Level7Star2;
            scoreStar3 = GameManager.Level7Star3;
        }
        else if (level8)
        {
            scoreStar1 = GameManager.Level8Star1;
            scoreStar2 = GameManager.Level8Star2;
            scoreStar3 = GameManager.Level8Star3;
        }
        #endregion
    }

    void Update()
    {
        if (initialLevelDelay >= 0 && !roundStarted)
        {
            initialLevelDelay -= Time.deltaTime;

            countdownClock.text = initialLevelDelay.ToString("F0");

            if (initialLevelDelay >= 3)
            {
                countdownText.text = "Get Ready!";
            }
            else if (initialLevelDelay <= 3 && initialLevelDelay >= .5f)
            {
                countdownText.text = "Get Set!";
            }
            else
            {
                countdownText.text = "Go!";
                //turn player on
                player.GetComponent<PlayerMovement>().enabled = true;
            }
        }
        else
        {
            countdownWindow.SetBool("Collapse", true);
            StartCoroutine("Waiting");
        }

        if (!stopCountDown)
        {
            roundStarted = true;
            seconds -= Time.deltaTime;
            if (minutes <= 0 && seconds <= 30)
            {
                Country.pitch = 1.25f;
            }

            if (minutes <= 0 && seconds <= 15)
            {
                Country.pitch = 1.5f;
            }

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
                    GameObject[] human = GameObject.FindGameObjectsWithTag("Human");
                    foreach (GameObject go in human)
                    {
                        Destroy(go);
                    }


                    player.GetComponent<PlayerMovement>().enabled = false;
                    Country.pitch = 1f;
                    TimeRemaining.text = "0:00";
                    stopCountDown = true;
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

        scoreText.text = (score + (goldScore * 5)).ToString();
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSeconds(3);
        cowsCollected.text = score.ToString();

        goldCollectedRaw.text = goldScore.ToString();

        goldCollected.text = (5 * goldScore).ToString();

        total = (goldScore * 5) + score;

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

        #region UpdateGameManagerScore
        if (level1 && GameManager.highestLevel1Score <= total)
        {
            GameManager.highestLevel1Score = total;
        }

        else if (level2 && GameManager.highestLevel2Score <= total)
        {
            GameManager.highestLevel2Score = total;
        }

        else if (level3 && GameManager.highestLevel3Score <= total)
        {
            GameManager.highestLevel3Score = total;
        }

        else if (level4 && GameManager.highestLevel4Score <= total)
        {
            GameManager.highestLevel4Score = total;
        }

        else if (level5 && GameManager.highestLevel5Score <= total)
        {
            GameManager.highestLevel5Score = total;
        }

        else if (level6 && GameManager.highestLevel6Score <= total)
        {
            GameManager.highestLevel6Score = total;
        }

        else if (level7 && GameManager.highestLevel7Score <= total)
        {
            GameManager.highestLevel7Score = total;
        }

        else if (level8 && GameManager.highestLevel8Score <= total)
        {
            GameManager.highestLevel8Score = total;
        }
        #endregion
        GameManager.SaveGame();

        Continue.SetActive(true);

       // Time.timeScale = 0;
    }

    public void ContinueButton()
    {
        //Time.timeScale = 1;

        score = 0;
        goldScore = 0;

        if (!goToCredits)
        {
            SceneManager.LoadScene("LevelSelect");
        }
        else
            SceneManager.LoadScene("CityToEnd");
    }

    public static void GateOpenedUIActive()
    {
        gateOpenedUI.SetActive(true);
        score = 0;
        goldScore = 0;
        total = 0;
        GameManager.gateOpened = true;
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        roundStarted = true;
        stopCountDown = false;
        yield return new WaitForSeconds(2f);
        countdownObject.SetActive(false);
    }
}
