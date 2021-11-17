using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject Camera;
    public float playerSpeed = 10;
    public float CameraFollowSpeed;
    private Vector3 CamOffSet;

    void Start()
    {
        CamOffSet = Camera.transform.position - transform.position;
    }

    void FixedUpdate()
    {
       // transform.position += new Vector3(Input.GetAxis("Horizontal") * playerSpeed * Time.smoothDeltaTime, 0, Input.GetAxis("Vertical"));
        Camera.transform.position = Vector3.Lerp(Camera.transform.position, transform.position + CamOffSet, Time.smoothDeltaTime * CameraFollowSpeed);
    }
}
