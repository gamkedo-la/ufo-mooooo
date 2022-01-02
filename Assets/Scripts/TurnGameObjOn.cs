using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGameObjOn : MonoBehaviour
{
    public GameObject menu, anim;
    public void TimingTrigger()
    {
        menu.SetActive(true);
        anim.SetActive(false);
    }
}
