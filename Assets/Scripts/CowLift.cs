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

    public bool canMove;
    public float travelingSpeed;

    bool isMoving;
    float minStay = 3, maxStay = 15;
    public float currentStay;
    float minMove = 3, maxMove = 15;
    public float currentMove;
    bool hasPickedRotation;

    bool inWater;
    public float waterLife = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentStay = Random.Range(minStay, maxStay);
        transform.rotation = Quaternion.Euler(0,Random.Range(0, 360), 0);
        currentMove = Random.Range(minMove, maxMove);
    }

    private void Update()
    {
        if (inWater)
        {
            waterLife -= Time.deltaTime;
            if (waterLife <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (!isInGoal)
        {
            if (!canMove)
            {
                if (isBeingLevitated)
                {
                    rb.velocity = transform.up * levitateSpeed;
                    print("here");
                    //transform.Translate(Vector3.up * Time.deltaTime * levitateSpeed);
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
                    canMove = true;
                }
            }

            if (canMove)
            {
                currentMove -= Time.deltaTime;
                if (isMoving)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * travelingSpeed);
                }

                if (currentMove >= 0)
                {
                    isMoving = true;
                }

                else
                {       
                    isMoving = false;
                    currentMove = 0;
                    StartCoroutine(WaitForRotate());
                }
            }
        }

        if (isInGoal)
        {
            if (GameManager.gateOpened)
            {
                GetComponent<BoxCollider>().enabled = true;
                rb.constraints = RigidbodyConstraints.None;

                transform.LookAt(GameObject.FindGameObjectWithTag("OutsideTarget").transform);

                transform.Translate(Vector3.forward * Time.deltaTime * travelingSpeed * 5);
                StartCoroutine(CooldownOnGate());
            }

            else
            {
                GetComponent<BoxCollider>().enabled = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
            }
        }
    }

    IEnumerator WaitForRotate()
    {
        yield return new WaitForSeconds(currentStay);
        if (!isMoving)
        {
            currentMove = Random.Range(minMove, maxMove);
            currentStay = Random.Range(minStay, maxStay);
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
        isMoving = true;
    }

    IEnumerator WaitForGoal()
    {
        yield return new WaitForSeconds(.1f);

        currentMove = Random.Range(minMove, maxMove);
        currentStay = Random.Range(minStay, maxStay);
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
    }

    IEnumerator CooldownOnGate()
    {
        yield return new WaitForSeconds(5f);
        isInGoal = false;
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
                canMove = false;
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

        if (other.tag == "OutsideTarget")
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            isMoving = true;
            isInGoal = false;
            StartCoroutine(WaitForGoal());
        }

        if (other.tag == "Water")
        {
            inWater = true;
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
                canMove = true;
            }

            if (other.tag == "Stopper")
            {
                hitTop = false;
                isBeingLevitated = false;
                rb.useGravity = true;
                this.transform.parent = null;
            }
            if (other.tag == "Water")
            {
                inWater = false;
            }

        }
    }
}
