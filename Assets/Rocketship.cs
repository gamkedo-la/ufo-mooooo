using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketship : MonoBehaviour
{
    Transform ship;
    public float speed = 2f;

    bool hasCollided;
    public GameObject explosionEffect;
    public GameObject mainRocket, frontRocket;

    private void Start()
    {
        ship = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (!hasCollided)
        {
            transform.LookAt(ship);
            transform.position = Vector3.MoveTowards(transform.position, ship.transform.position, speed);
        }
        else
        {
            explosionEffect.SetActive(true);
            mainRocket.GetComponent<MeshRenderer>().enabled = false;
            frontRocket.GetComponent<MeshRenderer>().enabled = false;

            this.GetComponent<SphereCollider>().radius *= 1.1f;
            StartCoroutine(Waiting());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Stopper")
        {
            hasCollided = true;
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
