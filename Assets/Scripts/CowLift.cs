using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowLift : MonoBehaviour
{
    Rigidbody rb;
    public float levitateSpeed = 2.5f;
    bool isBeingLevitated;
    bool hitTop;

    bool isInGoal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!isInGoal)
        {
            if (isBeingLevitated)
            {
                rb.velocity = transform.up * levitateSpeed;
            }

            if (hitTop)
            {
                isBeingLevitated = false;
                rb.velocity = transform.up * 0;
            }

            if (Input.GetKeyUp(KeyCode.Space) && (hitTop || isBeingLevitated))
            {
                isBeingLevitated = false;
                hitTop = false;
                rb.useGravity = true;
                this.transform.parent = null;
            }
        }

        if (isInGoal)
        {
            GetComponent<CowLift>().enabled = false;
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isInGoal)
        {
            if (other.tag == "Beam")
            {
                rb.useGravity = false;
                isBeingLevitated = true;
                this.transform.parent = GameObject.FindGameObjectWithTag("Beam").transform;
            }

            if (other.tag == "Stopper")
            {
                hitTop = true;
            }
        }
        if (other.tag == "Goal")
        {
            isInGoal = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isInGoal)
        {
            if (other.tag == "Beam")
            {
                rb.useGravity = true;
                isBeingLevitated = false;
                this.transform.parent = null;
            }

            if (other.tag == "Stopper")
            {
                hitTop = false;
                isBeingLevitated = false;
                rb.useGravity = true;
                this.transform.parent = null;
            }
        }
    }
}
