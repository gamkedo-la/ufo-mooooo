using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject anim, menu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            menu.SetActive(true);
            anim.SetActive(false);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("IntroCut");
    }

    public void LoadGame()
    {
        GameManager.LoadGame();
        SceneManager.LoadScene("LevelSelect");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
