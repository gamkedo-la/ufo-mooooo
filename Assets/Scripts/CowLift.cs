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

    private void LateUpdate() // after beam/player/camera position to reduce stutter
    {
        if (inWater)
        {
            waterLife -= Time.deltaTime;
            if (waterLife <= 0)
            {
                Destroy(this.gameObject);
            }
        }

        if (isBeingLevitatedTo != null) { // even if we've been in a goal, do some bug prevention
            Vector3 facing = transform.forward;
            facing.y = 0.0f; // flatten
            transform.rotation = Quaternion.LookRotation(facing); // preventing tilt stretch bug
            rb.constraints = RigidbodyConstraints.FreezeRotation; // releases bug that sometimes locks up gold cow
            isInGoal = false; // workaround for cases of escaped cow stuck in beam
        }

        if (!isInGoal)
        {
            if (isBeingLevitatedTo != null)
            {
                if (transform.position.y <= isBeingLevitatedTo.transform.position.y)
                {
                    //Smooth transition
                    //transform.position += Vector3.up * levitateSpeed * Time.deltaTime;

                    //jump to stopper position
                    // transform.position = isBeingLevitatedTo.transform.position;

                    //Smooth vertical transition with lateral alignment enforcement so we don't drop them
                    Vector3 newPosition = isBeingLevitatedTo.transform.position;
                    newPosition.y = transform.position.y + levitateSpeed * Time.deltaTime * 2.0f;
                    transform.position = newPosition;
                    Vector3 facing = transform.forward;
                    facing.y = 0.0f; // flatten
                    transform.rotation = Quaternion.LookRotation(facing); // preventing tilt stretch bug

                } else
                {
                    //if it is near/above us this will lock it to us
                    transform.position = isBeingLevitatedTo.transform.position;
                    Vector3 facing = transform.forward;
                    facing.y = 0.0f; // flatten
                    transform.rotation = Quaternion.LookRotation(facing); // preventing tilt stretch bug
                }

                if (Input.GetKeyUp(KeyCode.Space))
                {
                    isBeingLevitatedTo = null;
                    rb.velocity = Vector3.zero;
                    rb.useGravity = true;
                    gameObject.layer = LayerMask.NameToLayer("Default");
                    this.transform.parent = null;
                    rb.constraints = RigidbodyConstraints.FreezeRotation; // releases bug that sometimes locks up gold cow
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
                rb.constraints = RigidbodyConstraints.FreezeRotation; // was None, led to some tilted stretched cows

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

        if (transform.parent == null)
        {
            rb.useGravity = true;
            gameObject.layer = LayerMask.NameToLayer("Default");
            isBeingLevitatedTo = null;
            transform.parent = null;
           // rb.velocity = Vector3.zero;
            transform.localScale = new Vector3(1, 1, 1);
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
            gameObject.layer = LayerMask.NameToLayer("CowInBeam");
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
                gameObject.layer = LayerMask.NameToLayer("Default");
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
