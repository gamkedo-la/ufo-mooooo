using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float verticalSpeed = 3;
    float horizontalSpeed;
    public float baseSpeed = 15;
    public float doubledSpeed = 30;

    public GameObject beam;
    public GameObject beamAnimation;

    bool controllerDisabled;

    public GameObject ship;

    public CharacterController controller;
    private AudioSource UFOBeamSound;

    public GameObject cowStopper;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        UFOBeamSound = GetComponent<AudioSource>();
        UFOBeamSound.volume = 0.0f;

        horizontalSpeed = doubledSpeed;
    }

    private void FixedUpdate() {
        float beamFade = 0.1f;
        float targetVol;
        if(beamAnimation.activeSelf) {
            targetVol = 1.0f;
        } else {
            targetVol = 0.0f;
        }
        UFOBeamSound.volume = beamFade * targetVol + (1.0f - beamFade) * UFOBeamSound.volume;
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
                horizontalSpeed = baseSpeed;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                BeamRetract();
                horizontalSpeed = doubledSpeed;
            }
            #endregion
        }

        else
        {
            beam.GetComponent<CapsuleCollider>().enabled = false;
            beamAnimation.SetActive(false);
        }
    }

    public void BeamRetract()
    {
        beam.GetComponent<CapsuleCollider>().enabled = false;
        beamAnimation.SetActive(false);
        cowStopper.transform.DetachChildren();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rocket")
        {
            controllerDisabled = true;
            rb.useGravity = true;
            BeamRetract();
            StartCoroutine(ReturnControl());
        }
    }

    IEnumerator ReturnControl()
    {
        controller.enabled = false;
        #region ToggleMeshRenderer
        yield return new WaitForSeconds(.25f);
        ship.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        ship.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(.25f);
        ship.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(.25f);
        ship.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(.2f);
        ship.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(.2f);
        ship.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(.15f);
        ship.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(.15f);
        ship.GetComponent<MeshRenderer>().enabled = true;
        yield return new WaitForSeconds(.15f);
        ship.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(.15f);
        ship.GetComponent<MeshRenderer>().enabled = true;
        #endregion


        rb.useGravity = false;
        controllerDisabled = false;
        controller.enabled = true;
    }
}
