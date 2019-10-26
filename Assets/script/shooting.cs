using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject fireBullet;
    public float bulletSpeed;
    public int player;
    public AudioClip shootSound;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Abutton" + player.ToString())) {
            shoot();
        }
            
    }

    void shoot() {
        GameObject bullet = Instantiate(fireBullet, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(shootPoint.up * bulletSpeed);
        Destroy(bullet, 2.5f);
        audioSource.PlayOneShot(shootSound);
    }
}
