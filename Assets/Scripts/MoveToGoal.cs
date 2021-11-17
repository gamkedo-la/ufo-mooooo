using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToGoal : MonoBehaviour
{
    Transform gate;
    NavMeshAgent navMesh;

    Rigidbody rb;
    public float levitateSpeed = 2.5f;
    bool isBeingLevitated;
    bool hitTop;

    bool initialLanding;

    public GameObject humanHolder;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMesh = GetComponent<NavMeshAgent>();
        gate = GameObject.FindWithTag("Gate").transform;

        rb.useGravity = true;
        navMesh.enabled = false;
    }

    private void Update()
    {
       if (isBeingLevitated)
       {
            rb.velocity = transform.up * levitateSpeed;
            navMesh.enabled = false; 
       }

        else
        {
            if (initialLanding)
            {
                navMesh.destination = gate.position;
                navMesh.enabled = true;
            }
        }

        if (hitTop)
        {
            isBeingLevitated = false;
            rb.velocity = transform.up * 0;
        }

        if (Input.GetKeyUp(KeyCode.Space) && (hitTop || isBeingLevitated))
        {
            rb.velocity = transform.up * -5f;
            hitTop = false;
            rb.useGravity = true;
            this.transform.parent = null;
            humanHolder.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y, -180);
        }
    }

    private void OnTriggerEnter(Collider other)
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

        if (other.tag == "Ground")
        {
            initialLanding = true;
            navMesh.enabled = true;
            rb.useGravity = false;

            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.FreezeAll;
            this.transform.parent = null;
            StartCoroutine(Waiting());
        }
    }

    private void OnTriggerExit(Collider other)
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

        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        humanHolder.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y, 0);
        rb.constraints = RigidbodyConstraints.None;
        isBeingLevitated = false;
    }
}
