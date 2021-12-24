using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicRotation : MonoBehaviour
{
    public float minRotation, maxRotation;
    float rotation;
    public bool startForward;

    private void Update()
    {
        if (startForward)
        {
            rotation += Time.deltaTime;
            if (rotation >= maxRotation)
            {
                startForward = false;
            }
        }
        else
        {
            rotation -= Time.deltaTime;
            if (rotation <= maxRotation)
            {
                startForward = true;
            }
        }

    }
}
