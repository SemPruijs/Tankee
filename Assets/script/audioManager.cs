using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioManager : MonoBehaviour
{
    public AudioClip map1;

    public AudioSource audioSource;
    void Start()
    {
        audioSource.clip = map1;
        audioSource.Play();
    }
}
