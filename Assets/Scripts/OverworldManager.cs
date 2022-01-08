using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    public GameObject Level1Star1, Level1Star2, Level1Star3;
    public GameObject Level2Star1, Level2Star2, Level2Star3;
    public GameObject Level3Star1, Level3Star2, Level3Star3;
    public GameObject Level4Star1, Level4Star2, Level4Star3;
    public GameObject Level5Star1, Level5Star2, Level5Star3;
    public GameObject Level6Star1, Level6Star2, Level6Star3;
    public GameObject Level7Star1, Level7Star2, Level7Star3;
    public GameObject Level8Star1, Level8Star2, Level8Star3;

    public GameObject PreLevel1Star1, PreLevel1Star2, PreLevel1Star3;
    public GameObject PreLevel2Star1, PreLevel2Star2, PreLevel2Star3;
    public GameObject PreLevel3Star1, PreLevel3Star2, PreLevel3Star3;
    public GameObject PreLevel4Star1, PreLevel4Star2, PreLevel4Star3;
    public GameObject PreLevel5Star1, PreLevel5Star2, PreLevel5Star3;
    public GameObject PreLevel6Star1, PreLevel6Star2, PreLevel6Star3;
    public GameObject PreLevel7Star1, PreLevel7Star2, PreLevel7Star3;
    public GameObject PreLevel8Star1, PreLevel8Star2, PreLevel8Star3;

    public GameObject player;

    public GameObject CtoF1, F1toF2, F2toC,
                      CtoI1, I1toI2, I2toC,
                      CtoD1, D1toD2, D2toC,
                      CtoC1, C1toC2;

    private void Start()
    {
        if (GameManager.playerPreservedSpace.x == 0 && GameManager.playerPreservedSpace.y == 0 && GameManager.playerPreservedSpace.z == 0)
        {
            player.transform.position = new Vector3(-20.59f, -1.4f, -36.88f);
        }
        else
        {
            player.transform.position = GameManager.playerPreservedSpace;
        }

        //Farm
        if (GameManager.tempCtoF1 || GameManager.tempCtoF1)
        {
            CtoF1.SetActive(true);
        }

        if (GameManager.highestLevel1Score >= GameManager.Level1Star1)
        {
            F1toF2.SetActive(true);
        }

        if (GameManager.highestLevel2Score >= GameManager.Level2Star1)
        {
            F2toC.SetActive(true);
        }

        //Island

        if (GameManager.tempCtoI1 || GameManager.tempCtoI1)
        {
            CtoI1.SetActive(true);
        }

        if (GameManager.highestLevel3Score >= GameManager.Level3Star1)
        {
            I1toI2.SetActive(true);
        }

        if (GameManager.highestLevel4Score >= GameManager.Level4Star1)
        {
            I2toC.SetActive(true);
        }

        //Desert

        if (GameManager.tempCtoD1 || GameManager.tempCtoD1)
        {
            CtoD1.SetActive(true);
        }

        if (GameManager.highestLevel5Score >= GameManager.Level5Star1)
        {
            D1toD2.SetActive(true);
        }

        if (GameManager.highestLevel6Score >= GameManager.Level6Star1)
        {
            D2toC.SetActive(true);
        }

        //City

        if (GameManager.tempCtoC1 || GameManager.tempCtoC1)
        {
            CtoC1.SetActive(true);
        }

        if (GameManager.highestLevel7Score >= GameManager.Level7Star1)
        {
            C1toC2.SetActive(true);
        }
    }

    private void Awake()
    {
        #region Determine if stars are on
        //Level 1
        if (GameManager.highestLevel1Score >= GameManager.Level1Star1)
        {
            Level1Star1.SetActive(true);
            PreLevel1Star1.SetActive(true);
        }
        if (GameManager.highestLevel1Score >= GameManager.Level1Star2)
        {
            Level1Star2.SetActive(true);
            PreLevel1Star2.SetActive(true);
        }
        if (GameManager.highestLevel1Score >= GameManager.Level1Star3)
        {
            Level1Star3.SetActive(true);
            PreLevel1Star3.SetActive(true);
        }

        //Level 2
        if (GameManager.highestLevel2Score >= GameManager.Level2Star1)
        {
            Level2Star1.SetActive(true);
            PreLevel2Star1.SetActive(true);
        }
        if (GameManager.highestLevel2Score >= GameManager.Level2Star2)
        {
            Level2Star2.SetActive(true);
            PreLevel2Star2.SetActive(true);
        }
        if (GameManager.highestLevel2Score >= GameManager.Level2Star3)
        {
            Level2Star3.SetActive(true);
            PreLevel2Star3.SetActive(true);
        }

        //Level 3
        if (GameManager.highestLevel3Score >= GameManager.Level3Star1)
        {
            Level3Star1.SetActive(true);
            PreLevel3Star1.SetActive(true);
        }
        if (GameManager.highestLevel3Score >= GameManager.Level3Star2)
        {
            Level3Star2.SetActive(true);
            PreLevel3Star2.SetActive(true);
        }
        if (GameManager.highestLevel3Score >= GameManager.Level3Star3)
        {
            Level3Star3.SetActive(true);
            PreLevel3Star3.SetActive(true);
        }

        //Level 4
        if (GameManager.highestLevel4Score >= GameManager.Level4Star1)
        {
            Level4Star1.SetActive(true);
            PreLevel4Star1.SetActive(true);
        }
        if (GameManager.highestLevel4Score >= GameManager.Level4Star2)
        {
            Level4Star2.SetActive(true);
            PreLevel4Star2.SetActive(true);
        }
        if (GameManager.highestLevel4Score >= GameManager.Level4Star3)
        {
            Level4Star3.SetActive(true);
            PreLevel4Star3.SetActive(true);
        }

        //Level 5
        if (GameManager.highestLevel5Score >= GameManager.Level5Star1)
        {
            Level5Star1.SetActive(true);
            PreLevel5Star1.SetActive(true);
        }
        if (GameManager.highestLevel5Score >= GameManager.Level5Star2)
        {
            Level5Star2.SetActive(true);
            PreLevel5Star2.SetActive(true);
        }
        if (GameManager.highestLevel5Score >= GameManager.Level5Star3)
        {
            Level5Star3.SetActive(true);
            PreLevel5Star3.SetActive(true);
        }

        //Level 6
        if (GameManager.highestLevel6Score >= GameManager.Level6Star1)
        {
            Level6Star1.SetActive(true);
            PreLevel6Star1.SetActive(true);
        }
        if (GameManager.highestLevel6Score >= GameManager.Level6Star2)
        {
            Level6Star2.SetActive(true);
            PreLevel6Star2.SetActive(true);
        }
        if (GameManager.highestLevel6Score >= GameManager.Level6Star3)
        {
            Level6Star3.SetActive(true);
            PreLevel6Star3.SetActive(true);
        }

        //Level 7
        if (GameManager.highestLevel7Score >= GameManager.Level7Star1)
        {
            Level7Star1.SetActive(true);
            PreLevel7Star1.SetActive(true);
        }
        if (GameManager.highestLevel7Score >= GameManager.Level7Star2)
        {
            Level7Star2.SetActive(true);
            PreLevel7Star2.SetActive(true);
        }
        if (GameManager.highestLevel7Score >= GameManager.Level7Star3)
        {
            Level7Star3.SetActive(true);
            PreLevel7Star3.SetActive(true);
        }

        //Level 8
        if (GameManager.highestLevel8Score >= GameManager.Level8Star1)
        {
            Level8Star1.SetActive(true);
            PreLevel8Star1.SetActive(true);
        }
        if (GameManager.highestLevel8Score >= GameManager.Level8Star2)
        {
            Level8Star2.SetActive(true);
            PreLevel8Star2.SetActive(true);
        }
        if (GameManager.highestLevel8Score >= GameManager.Level8Star3)
        {
            Level8Star3.SetActive(true);
            PreLevel8Star3.SetActive(true);
        }
        #endregion
    }
}
