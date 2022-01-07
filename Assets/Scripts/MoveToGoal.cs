using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MoveToGoal : MonoBehaviour
{
    Transform gate;
    NavMeshAgent navMesh;

    Rigidbody rb;
    public float levitateSpeed = 2.5f;
    public Transform isBeingLevitatedTo;

    bool isBeingLevitated;
    bool hitTop;

    bool initialLanding;

    public GameObject humanHolder;

    GameObject humanSpottedText;

    public bool isCityHuman;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        navMesh = GetComponent<NavMeshAgent>();

        if (!isCityHuman)
        {
            gate = GameObject.FindWithTag("Gate").transform;
        }

        else
            gate = GameObject.FindGameObjectWithTag("GroundTrigger").transform;


        rb.useGravity = true;
        navMesh.enabled = false;

        humanSpottedText = GameObject.FindGameObjectWithTag("HumanSpotted");
        humanSpottedText.GetComponent<Text>().text = "Human Spotted!".ToString();
    }

    private void Update()
    {
        if (isBeingLevitatedTo != null)
        {
            if (transform.position.y <= isBeingLevitatedTo.transform.position.y)
            {
                transform.position += Vector3.up * levitateSpeed * Time.deltaTime;
                //transform.position = isBeingLevitatedTo.transform.position;
            }
            else
            {
                //if it is near/above us this will lock it to us
                transform.position = isBeingLevitatedTo.transform.position;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isBeingLevitatedTo = null;
                rb.velocity = Vector3.zero;
                rb.useGravity = true;
                this.transform.parent = null;
            }
        }

        else
        {
            if (initialLanding && navMesh.enabled)
            {
                navMesh.destination = gate.position;
            }
        }

        Vector3 facing = transform.forward;
        facing.y = 0.0f; // flatten
        transform.rotation = Quaternion.LookRotation(facing); // preventing tilt stretch bug
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Beam")
        {
            navMesh.enabled = false;
            rb.useGravity = false;
            isBeingLevitatedTo = other.gameObject.GetComponent<TargetStopperHeight>().stopperHeight;
            transform.parent = isBeingLevitatedTo.transform;
        }

        if (other.tag == "Stopper")
        {
            DestroySelf();
            //hitTop = true;
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
            isBeingLevitatedTo = null;
            transform.parent = null;
            rb.velocity = Vector3.zero;
            isBeingLevitatedTo = null;
        }

        if (other.tag == "Stopper")
        {
            hitTop = false;
            isBeingLevitated = false;
            DestroySelf();
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        humanHolder.transform.Rotate(this.transform.rotation.x, this.transform.rotation.y, 0);
        rb.constraints = RigidbodyConstraints.None;
        isBeingLevitated = false;
    }

    void DestroySelf()
    {
        GameObject[] humansActive = GameObject.FindGameObjectsWithTag("Human");
        if (humansActive.Length > 1)
        {
            //Don't do anything, there are others
        }
        else if (humansActive.Length == 1)
        {
            humanSpottedText.GetComponent<Text>().text = "".ToString();
        }
        Destroy(this.gameObject);
    }
}
