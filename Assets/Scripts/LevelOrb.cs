using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelOrb : MonoBehaviour
{
    public bool levelUnlocked;
    public GameObject baseLevelScreen;
    public GameObject specificLevelScreen;

    public GameObject miniWindowOpen;

    bool canBeOpened;

    private void Update()
    {
        if (canBeOpened)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                baseLevelScreen.SetActive(true);
                specificLevelScreen.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canBeOpened = true;
            miniWindowOpen.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        baseLevelScreen.SetActive(false);
        specificLevelScreen.SetActive(false);

        canBeOpened = false;
        miniWindowOpen.SetActive(false);
    }

}
