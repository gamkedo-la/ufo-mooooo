using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnStart : MonoBehaviour
{
    public bool right, up, forward;
    public float rotateSpeed;

    private void Update()
    {
        if (right)
        {
            this.transform.Rotate(Vector3.right, Time.deltaTime * rotateSpeed); 
        }

        else if (up)
        {
            this.transform.Rotate(Vector3.up, Time.deltaTime * rotateSpeed);
        }

        else if (forward)
        {
            this.transform.Rotate(Vector3.forward, Time.deltaTime * rotateSpeed);
        }
    }
}
