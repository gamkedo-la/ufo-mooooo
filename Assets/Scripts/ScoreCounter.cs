using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    public int cowScore = 1;
    public int goldCowScore = 1;
    public int humanScore = -5;

    public bool canChange;
    public float timerToChange;
    public Transform newLocation;

    public bool canChangeAgain;
    public float timerToChangeAgain;
    public Transform newLocationAgain;

    public Text score;
    public Text goalChanged;

    private void Update()
    {
        if (GameManager.gateOpened)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        else
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }

        if (canChange)
        {
            if (timerToChange >= 0)
            {
                timerToChange -= Time.deltaTime;
            }

            if (timerToChange <= 0)
            {
                gameObject.transform.position = newLocation.transform.position;
                goalChanged.text = "Goal moved!";
                StartCoroutine(Waiting());
            }
        }

        if (canChangeAgain)
        {
            if (timerToChangeAgain >= 0)
            {
                timerToChangeAgain -= Time.deltaTime;
            }

            if (timerToChangeAgain <= 0)
            {
                gameObject.transform.position = newLocationAgain.transform.position;
                goalChanged.text = "Goal moved!";
                StartCoroutine(WaitingAgain());
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cow")
        {
            LevelManager.score += cowScore;
        }

        if (other.tag == "GoldCow")
        {
            LevelManager.goldScore += goldCowScore;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Cow")
        {
            LevelManager.score -= cowScore;
        }

        if (other.tag == "GoldCow")
        {
            LevelManager.goldScore -= goldCowScore;
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(3);
        goalChanged.text = "";
        timerToChange = 0;
        canChange = false;
    }

     IEnumerator WaitingAgain()
    {
        yield return new WaitForSeconds(3);
        goalChanged.text = "";
        timerToChangeAgain = 0;
        canChangeAgain = false;
    }
}
