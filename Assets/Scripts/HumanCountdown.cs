using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanCountdown : MonoBehaviour
{
    public bool isContacted;
    public Animator anim;
    float startingTime = 5f;
    public float countdown = 5f;
    
    void Update()
    {
        if (isContacted)
        {
            countdown -= Time.deltaTime;
        }

        if (countdown <= 0)
        {
            anim.SetBool("isOpen", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Human")
        {
            isContacted = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Human")
        {
            if (countdown <= 0)
            {
                LevelManager.GateOpenedUIActive();
                GameObject humanToDestroy = other.gameObject;
                Destroy(humanToDestroy);
                StartCoroutine(Waiting());
                
            }
            else
            {
                isContacted = false;
                countdown = startingTime;
                anim.SetBool("isOpen", false);
            }
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(5);

        isContacted = false;
        countdown = startingTime;
        anim.SetBool("isOpen", false);
    }
}
