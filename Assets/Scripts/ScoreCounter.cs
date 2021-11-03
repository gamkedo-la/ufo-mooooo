using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int Score;
    public int cowScore = 1;
    public int goldCowScore = 1;
    public int humanScore = -5;
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
}
