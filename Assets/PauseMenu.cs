using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuGameObject;
    bool pauseToggled;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseToggled = !pauseToggled;
        }

        if (pauseToggled)
        {
            PauseMenuGameObject.SetActive(true);
            Time.timeScale = 0;
        }

        else
        {
            PauseMenuGameObject.SetActive(false);
            ToggleTime();
        }
    }

    public void Resume()
    {
        pauseToggled = !pauseToggled;
        PauseMenuGameObject.SetActive(false);
        ToggleTime();
    }

    public void Restart()
    {
        pauseToggled = !pauseToggled;
        ToggleTime();
        //Set current score to 0
        LevelManager.score = 0;
        LevelManager.goldScore = 0;
        LevelManager.humanScore = 0;
        LevelManager.total = 0;
        //ReLoad room
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        pauseToggled = !pauseToggled;
        ToggleTime();
        //Set current score to 0
        LevelManager.score = 0;
        LevelManager.goldScore = 0;
        LevelManager.humanScore = 0;
        LevelManager.total = 0;
        //Load to level select
        SceneManager.LoadScene("LevelSelect");
    }

    void ToggleTime()
    {
        Time.timeScale = 1;
    }
}
