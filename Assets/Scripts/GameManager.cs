using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int Level1Star1 = 1, Level1Star2 = 3, Level1Star3 = 8;
    public static int Level2Star1, Level2Star2, Level2Star3;
    public static int Level3Star1, Level3Star2, Level3Star3;
    public static int Level4Star1, Level4Star2, Level4Star3;
    public static int Level5Star1, Level5Star2, Level5Star3;
    public static int Level6Star1, Level6Star2, Level6Star3;
    public static int Level7Star1, Level7Star2, Level7Star3;
    public static int Level8Star1, Level8Star2, Level8Star3;

    public static int highestLevel1Score, highestLevel2Score, highestLevel3Score, highestLevel4Score, 
                      highestLevel5Score, highestLevel6Score, highestLevel7Score, highestLevel8Score;

    public static bool gateOpened;

    public static Vector3 playerPreservedSpace;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public static void SaveGame()
    {
        PlayerPrefs.SetInt("Level1High", highestLevel1Score);
        PlayerPrefs.SetInt("Level2High", highestLevel2Score);
        PlayerPrefs.SetInt("Level3High", highestLevel3Score);
        PlayerPrefs.SetInt("Level4High", highestLevel4Score);
        PlayerPrefs.SetInt("Level5High", highestLevel5Score);
        PlayerPrefs.SetInt("Level6High", highestLevel6Score);
        PlayerPrefs.SetInt("Level7High", highestLevel7Score);
        PlayerPrefs.SetInt("Level8High", highestLevel8Score);

        print("Game Saved: " + highestLevel1Score);
    }

    public static void LoadGame()
    {
        highestLevel1Score = PlayerPrefs.GetInt("Level1High");
        highestLevel2Score = PlayerPrefs.GetInt("Level2High");
        highestLevel3Score = PlayerPrefs.GetInt("Level3High");
        highestLevel4Score = PlayerPrefs.GetInt("Level4High");
        highestLevel5Score = PlayerPrefs.GetInt("Level5High");
        highestLevel6Score = PlayerPrefs.GetInt("Level6High");
        highestLevel7Score = PlayerPrefs.GetInt("Level7High");
        highestLevel8Score = PlayerPrefs.GetInt("Level8High");

        print("Game Loaded: " + highestLevel1Score);
    }
}
