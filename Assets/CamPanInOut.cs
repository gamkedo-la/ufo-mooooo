using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPanInOut : MonoBehaviour
{
   public float panMin = 55, panMax = 65;
    public float speed = .5f;
    bool flip;
    float pan = 42;

    public Camera mainCam;
    public void Update()
    {
        if (flip)
        {
            pan += Time.deltaTime * speed;
        }
        else
        {
            pan -= Time.deltaTime * speed;
        }

        if (pan >= panMax)
        {
            flip = false;
        }
        else if (pan <= panMin)
        {
            flip = true;
        }

        mainCam.fieldOfView = pan;
    }
}
