using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    public int cowScore = 1;
    public int goldCowScore = 1;
    public int humanScore = -5;

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

        if (other.tag == "Human")
        {
            LevelManager.humanScore += humanScore;
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

        if (other.tag == "Human")
        {
            LevelManager.humanScore -= humanScore;
        }
    }
}
