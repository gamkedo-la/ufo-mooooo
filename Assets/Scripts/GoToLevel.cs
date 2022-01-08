using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public string RoomToGoTo;
    public GameObject player;
    public void RoomTravel()
    {
        GameManager.playerPreservedSpace = player.transform.position;

        SceneManager.LoadScene(RoomToGoTo);
    }   
}
