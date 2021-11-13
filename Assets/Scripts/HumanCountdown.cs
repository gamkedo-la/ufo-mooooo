using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCountdown : MonoBehaviour
{
    public bool isContacted;
    public Animator anim;
    float startingTime = 5f;
    public float countdown = 5f;

    GameObject humanToDestroy;
    
    void Update()
    {
        if (isContacted)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            anim.SetBool("isOpen", true);
            StartCoroutine(WaitingForDestroy());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Human")
        {
            isContacted = true;
            humanToDestroy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Human")
        {
            if (countdown <= 0)
            {
   
            }
            if(countdown >= 0)
            {
                isContacted = false;
                countdown = startingTime;
                anim.SetBool("isOpen", false);
            }
        }
    }

    IEnumerator WaitingForDestroy()
    {
        yield return new WaitForSeconds(1);
        Destroy(humanToDestroy);
        LevelManager.GateOpenedUIActive();
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5);

        isContacted = false;
        countdown = startingTime;
        anim.SetBool("isOpen", false);
        GameManager.gateOpened = false;
    }
}
