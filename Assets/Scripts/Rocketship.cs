using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocketship : MonoBehaviour
{
    Transform ship;
    public float speed = 2f;

    bool hasCollided;
    public GameObject explosionEffect;
    public GameObject mainRocket;

    public float lifeTime = 10f;
    public GameObject rocket;
    public Material normal, red;

    private void Start()
    {
        ship = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 3 && lifeTime > 2)
        {
            //red
            rocket.GetComponent<MeshRenderer>().material = red;
        }
        else if (lifeTime <= 2 && lifeTime > 1)
        {
            //white
            rocket.GetComponent<MeshRenderer>().material = normal;
        }
        else if (lifeTime <= 1 && lifeTime > 0)
        {
            //red
            rocket.GetComponent<MeshRenderer>().material = red;
        }
        else if(lifeTime <= 0)
        {
            hasCollided = true;
        }

        if (!hasCollided)
        {
            transform.LookAt(ship);
            transform.position = Vector3.MoveTowards(transform.position, ship.transform.position, speed);
        }
        else
        {
            explosionEffect.SetActive(true);
            mainRocket.SetActive(false);

            this.GetComponent<SphereCollider>().radius *= 1.01f;
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
