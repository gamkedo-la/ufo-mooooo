using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public static int Level1Star1 = 1, Level1Star2 = 3, Level1Star3 = 8;
    public static int Level2Star1 = 1, Level2Star2 = 3, Level2Star3 = 8;
    public static int Level3Star1 = 1, Level3Star2 = 3, Level3Star3 = 8;
    public static int Level4Star1 = 1, Level4Star2 = 3, Level4Star3 = 8;
    public static int Level5Star1 = 1, Level5Star2 = 3, Level5Star3 = 8;
    public static int Level6Star1 = 1, Level6Star2 = 3, Level6Star3 = 8;
    public static int Level7Star1 = 1, Level7Star2 = 3, Level7Star3 = 8;
    public static int Level8Star1 = 1, Level8Star2 = 3, Level8Star3 = 8;

    public static int highestLevel1Score, highestLevel2Score, highestLevel3Score, highestLevel4Score, 
                      highestLevel5Score, highestLevel6Score, highestLevel7Score, highestLevel8Score;

    public static bool CtoF1, F1toF2, F2toC,
                       CtoI1, I1toI2, I2toC,
                       CtoD1, D1toD2, D2toC,
                       CtoC1, C1toC2;

    public static bool tempCtoF1, tempCtoI1, tempCtoD1, tempCtoC1;

    public static int VCtoF1, VF1toF2, VF2toC,
                       VCtoI1, VI1toI2, VI2toC,
                       VCtoD1, VD1toD2, VD2toC,
                       VCtoC1, VC1toC2;

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

        if (CtoF1)
        {
            VCtoF1 = 1;
        }


        if (F1toF2)
        {
            VF1toF2 = 1;
        }

        if (F2toC)
        {
            VF2toC = 1;          
        }

        if (CtoI1)
        {
            VCtoI1 = 1;          
        }

        if (I1toI2)
        {
            VI1toI2 = 1;          
        }

        if (I2toC)
        {
            VI2toC = 1;         
        }

        if (CtoD1)
        {
            VCtoD1 = 1;         
        }

        if (D1toD2)
        {
            VD1toD2 = 1;           
        }

        if (D2toC)
        {
            VD2toC = 1;           
        }

        if (CtoC1)
        {
            VCtoC1 = 1;            
        }

        if (C1toC2)
        {
            VC1toC2 = 1;
        }



        PlayerPrefs.SetInt("VCtoF1", VCtoF1);
        PlayerPrefs.SetInt("VF1toF2", VF1toF2);
        PlayerPrefs.SetInt("VF2toC", VF2toC);
        PlayerPrefs.SetInt("VCtoI1", VCtoI1);
        PlayerPrefs.SetInt("VI1toI2", VI1toI2);
        PlayerPrefs.SetInt("VI2toC", VI2toC);
        PlayerPrefs.SetInt("VCtoD1", VCtoD1);
        PlayerPrefs.SetInt("VD1toD2", VD1toD2);
        PlayerPrefs.SetInt("VD2toC", VD2toC);
        PlayerPrefs.SetInt("VCtoC1", VCtoC1);
        PlayerPrefs.SetInt("VC1toC2", VC1toC2);
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

        VCtoF1 = PlayerPrefs.GetInt("VCtoF1");
        VF1toF2 = PlayerPrefs.GetInt("VF1toF2");
        VF2toC = PlayerPrefs.GetInt("VF2toC");
        VCtoI1 = PlayerPrefs.GetInt("VCtoI1");
        VI1toI2 = PlayerPrefs.GetInt("VI1toI2");
        VI2toC = PlayerPrefs.GetInt("VI2toC");
        VCtoD1 = PlayerPrefs.GetInt("VCtoD1");
        VD1toD2 = PlayerPrefs.GetInt("VD1toD2");
        VD2toC = PlayerPrefs.GetInt("VD2toC");
        VCtoC1 = PlayerPrefs.GetInt("VCtoC1");
        VC1toC2 = PlayerPrefs.GetInt("VC1toC2");

        if (VCtoF1 == 1)
        {
            CtoF1 = true;
        }

        if (VF1toF2 == 1)
        {
            F1toF2 = true;
        }

        if (VF2toC == 1)
        {
            F2toC = true;
        }

        if (VCtoI1 == 1)
        {
            CtoI1 = true;
        }

        if (VI1toI2 == 1)
        {
            I1toI2 = true;
        }

        if (VI2toC == 1)
        {
            I2toC = true;
        }

        if (VCtoD1 == 1)
        {
            CtoD1 = true;
        }

        if (VD1toD2 == 1)
        {
            D1toD2 = true;
        }

        if (VD2toC == 1)
        {
            D2toC = true;
        }

        if (VCtoC1 == 1)
        {
            CtoC1 = true;
        }

        if (VC1toC2 == 1)
        {
            C1toC2 = true;
        }

        print("Game Loaded: " + highestLevel1Score);
    }
}
