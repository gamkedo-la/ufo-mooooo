using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rb;

    public float horizontalSpeed = 5;

    public CharacterController controller;

    public GameObject redShip;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GetComponent<BoxCollider>().enabled = false;
        GetComponent<CharacterController>().enabled = false;

        StartCoroutine(Waiting());
    }

    void LateUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float zAxis = Input.GetAxisRaw("zAxis");

        Vector3 direction = new Vector3(horizontal, 0, -vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * horizontalSpeed * Time.deltaTime);
        }

        if (direction.magnitude <= 0.1f)
        {
            controller.Move(direction * 0 * Time.deltaTime);
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<CharacterController>().enabled = true;
    }

}
