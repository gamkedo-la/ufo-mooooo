using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float verticalSpeed = 3;
    public float horizontalSpeed = 5;

    public GameObject beam;
    public GameObject beamAnimation;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        #region Movement
        //Forward
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.right * -horizontalSpeed;
        }

        //Backward
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.right * horizontalSpeed;
        }

        //Left
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = transform.forward * -horizontalSpeed;
        }

        //Right
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.forward * horizontalSpeed;
        }

        //Up
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.velocity = transform.up * verticalSpeed;
        }

        //Down
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = transform.up * -verticalSpeed;
        }
        #endregion

        #region KeyUp - Stop Movement
        //Forward
        if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = transform.right * 0;
        }

        //Backward
        if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = transform.right * 0;
        }

        //Left
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = transform.forward * 0;
        }

        //Right
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = transform.forward * 0;
        }

        //Up
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            rb.velocity = transform.up * 0;
        }

        //Down
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            rb.velocity = transform.up * 0;
        }
        #endregion

        #region Beam
        if (Input.GetKeyDown(KeyCode.Space))
        {
            beam.GetComponent<CapsuleCollider>().enabled = true;
            beamAnimation.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            beam.GetComponent<CapsuleCollider>().enabled = false;
            beamAnimation.SetActive(false);
        }
        #endregion
    }
}
