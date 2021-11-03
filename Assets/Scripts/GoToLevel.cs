using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public string RoomToGoTo;

    public void RoomTravel()
    {
        SceneManager.LoadScene(RoomToGoTo);
    }   
}
