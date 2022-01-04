using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CowLift : MonoBehaviour
{
    Rigidbody rb;
    public float levitateSpeed = 2.5f;
    public Transform isBeingLevitatedTo;

    public bool isInGoal;

    public float travelingSpeed;

    public bool isMoving;
    float minStay = 3, maxStay = 15;
    public float currentStay;
    float minMove = 3, maxMove = 15;
    public float currentMove;

    bool inWater;
    public float waterLife = 3f;

    AudioSource sound;
    int mooToPick;
    public AudioClip[] moo;
    public AudioClip fallingMoo;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentStay = Random.Range(minStay, maxStay);
        transform.rotation = Quaternion.Euler(0,Random.Range(0, 360), 0);
        currentMove = Random.Range(minMove, maxMove);

        mooToPick = Random.Range(0, moo.Length);
        sound = GetComponent<AudioSource>();
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
            if (isBeingLevitatedTo != null)
            {
                if (transform.position.y <= isBeingLevitatedTo.transform.position.y)
                {
                    //Smooth transition
                   // transform.position += Vector3.right * levitateSpeed * Time.deltaTime;

                    //jump to stopper position
                    transform.position = isBeingLevitatedTo.transform.position;
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
        if (other.tag == "Beam")
        {
            rb.useGravity = false;
            isBeingLevitatedTo = other.gameObject.GetComponent<TargetStopperHeight>().stopperHeight;
            transform.parent = isBeingLevitatedTo.transform;
            sound.PlayOneShot(moo[mooToPick], 1f);
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
                isBeingLevitatedTo = null;
                transform.parent = null;
                rb.velocity = Vector3.zero;
                transform.localScale = new Vector3(1, 1, 1);
            }

            if (other.tag == "Water")
            {
                inWater = false;
            }
            sound.PlayOneShot(fallingMoo, 1.5f);
        }
    }
}
