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

    bool controllerDisabled;

    public CharacterController controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!controllerDisabled)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            float zAxis = Input.GetAxisRaw("zAxis");

            Vector3 direction = new Vector3(vertical, zAxis, horizontal).normalized;

            if (direction.magnitude >= 0.1f)
            {
                controller.Move(direction * horizontalSpeed * Time.deltaTime);
            }

            if (direction.magnitude <= 0.1f)
            {
                controller.Move(direction * 0 * Time.deltaTime);
            }

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

        else
        {
            beam.GetComponent<CapsuleCollider>().enabled = false;
            beamAnimation.SetActive(false);

            /*rb.velocity = transform.right * 0;
            rb.velocity = transform.forward * 0;
            rb.velocity = transform.up * 0;
            */
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rocket")
        {
            controllerDisabled = true;
            rb.useGravity = true;
            StartCoroutine(ReturnControl());
        }
    }

    IEnumerator ReturnControl()
    {
        yield return new WaitForSeconds(3f);
        controllerDisabled = false;
        rb.useGravity = false;
    }
}
