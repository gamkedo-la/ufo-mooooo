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
        if (Camera!=null) {
            CamOffSet = Camera.transform.position - transform.position;
        } else {
            Debug.Log("The CameraFollow component is missing a Camera. Set one in the inspector!");
        }
    }

    void LateUpdate()
    {
        if (Camera!=null) {
            // transform.position += new Vector3(Input.GetAxis("Horizontal") * playerSpeed * Time.smoothDeltaTime, 0, Input.GetAxis("Vertical"));
            Camera.transform.position = Vector3.Lerp(Camera.transform.position, transform.position + CamOffSet, Time.smoothDeltaTime * CameraFollowSpeed);
        }
    }
}
