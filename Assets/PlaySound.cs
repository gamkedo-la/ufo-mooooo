using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioClip[] moo;
    public AudioSource sound;
    public void PickedUp()
    {
        sound.PlayOneShot(moo[Random.Range(0,moo.Length)], 1f);
    }
}
